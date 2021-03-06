﻿using UnityEngine;
using UnityEngine.UI;
using AssemblyCSharp;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
/// <summary>
/// World: Stores infomation pertaining to the world that other
/// classes require.
/// </summary>
public class World : MonoBehaviour {

	/// <summary>
	/// Points to the instance of the world, used to get
	/// data about the world.
	/// </summary>
	public static World data;

	public const int NUM_OF_LEVELS = 7;

	public readonly int[] STARS_IN_LEVEL = {0,0,0,1,0,3,3};

	public int highestLevel;

	public GameObject dove;
	/// <summary>
	/// The current global wind speed.
	/// </summary>
	private float windSpeed;

	private bool addingBalloon;

	public static bool restartedLevel = false; //required to keep music playing after pressing 'R' key

	public int totalStars;
	/// <summary>
	/// Destroy this instance if one exists, otherwise
	/// intializes it.
	/// </summary>
	void Start () {
		//If there is no World...
		if (data == null) {
			//Set the static instance to this object
			data = this;
			windSpeed = 0;
			highestLevel = -1;
			addingBalloon = false;
			totalStars = 0;
			while (File.Exists (Application.persistentDataPath + "/" + (highestLevel + 1).ToString () + ".dat"))
				highestLevel++;
			CalculateTotalStars ();
			DontDestroyOnLoad (gameObject);
		} 
		//Otherwise...
		else {
			//An instance exists, so destroy it
			Destroy (this.gameObject);
		}
	}
	
	/// <summary>
	/// Captures any revelant user input and update fields. accordingly.
	/// </summary>
	void Update () {
		windSpeed = Input.GetAxis ("Horizontal");
		if (Input.GetKey (KeyCode.R)) {
			UnityEngine.SceneManagement.SceneManager.LoadScene (
				UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex);
			restartedLevel = true;
		}

		if (Input.GetMouseButtonDown (0)) {
			if (addingBalloon) {
				Vector2 touchPostion = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				RaycastHit2D hit2D = Physics2D.Raycast (touchPostion, Vector2.zero);
				if (hit2D.collider != null && hit2D.collider.gameObject.GetComponent<AddBalloon> () != null) {
					AddBalloon target = hit2D.collider.gameObject.GetComponent<AddBalloon> ();
					target.AddNewBalloon ();
					DoveCount doveCount = GameObject.FindObjectOfType<DoveCount> ();
					doveCount.doveCount -= 1;
					if (doveCount.doveCount <= 0)
						UnityEngine.GameObject.Find ("DoveButton").GetComponent<Button>().interactable = false;

				}
				AddBalloon[] balloonable = UnityEngine.GameObject.FindObjectsOfType<AddBalloon> ();
				foreach (AddBalloon a in balloonable)
					a.highlight.SetActive(false);
				addingBalloon = false;
				dove.SetActive (false);
			}
		}
	}

	void OnLevelWasLoaded(int level){  //needed for persistent music
		StartCoroutine(wait(1));
		restartedLevel = false;
	}

	IEnumerator wait(int sec){
		yield return new WaitForSeconds(sec); //let newBGM's Awake() run
	}

	public void SetAddingBalloon(){
		AddBalloon[]  balloonable = UnityEngine.GameObject.FindObjectsOfType<AddBalloon> ();
		foreach (AddBalloon a in balloonable)
			a.highlight.SetActive(true);
		addingBalloon = true;
		dove.SetActive (true);
	}
	/// <summary>
	/// Get the global windspeed.
	/// </summary>
	/// <returns>The current windspeed.</returns>
	public float WindSpeed(){
		return 3*windSpeed;
	}

	private void CalculateTotalStars(){
		for (int i = 0; i < NUM_OF_LEVELS; i++)
		    if (File.Exists (Application.persistentDataPath + "/" + i.ToString () + ".dat")) {
			    //Open it for reading
			    BinaryFormatter bf = new BinaryFormatter ();
			    FileStream file = File.Open (Application.persistentDataPath + "/" + i.ToString () + ".dat", FileMode.Open);

			    //Extract the stars...
			    LevelInfo data = (LevelInfo)bf.Deserialize (file);

			    //Close the file
			    file.Close ();

			    totalStars += data.totalStarsCollected;
		    }
	}
	/// <summary>
	/// Gets the stars obtained for a given level.
	/// </summary>
	/// <returns>The stars obtained in a level.</returns>
	/// <param name="level">The Level in question.</param>
	public ArrayList GetStarsObtained(int level){
		//Check if the level file exists
		if (File.Exists (Application.persistentDataPath + "/" + level.ToString () + ".dat")) {
			//Open it for reading
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/" + level.ToString () + ".dat", FileMode.Open);

			//Extract the stars...
			LevelInfo data = (LevelInfo)bf.Deserialize (file);

			//Close the file
			file.Close ();

			//Get the collected stars
			ArrayList collected = new ArrayList ();
			for (int i = 0; i < data.starsCollected.Length; i++)
				if (data.starsCollected [i])
					collected.Add (i);
			return collected;
		}
		//If the level file doesn't exist, then no stars has been collected.
		return new ArrayList ();
	}
		

	public void SaveLevelInfo(int level){
		LevelInfo data;
		BinaryFormatter bf;
		FileStream file;

		GameObject[] uncollectedStars = UnityEngine.GameObject.FindGameObjectsWithTag ("star");

		if (File.Exists (Application.persistentDataPath + "/" + level.ToString () + ".dat")) {
			//Open it for reading
			bf = new BinaryFormatter ();
			file = File.Open (Application.persistentDataPath + "/" + level.ToString () + ".dat", FileMode.Open);

			//Extract the stars...
			data = (LevelInfo)bf.Deserialize (file);

			//Close the file
			file.Close ();

			totalStars -= data.totalStarsCollected;
		}

		data = new LevelInfo ();
		data.starsCollected = new bool[STARS_IN_LEVEL[level]];
		data.totalStarsCollected = 0;

		for (int i = 0; i < data.starsCollected.Length; i++) {
			data.starsCollected [i] = true;
			data.totalStarsCollected++;
			totalStars++;
		}
		
		foreach (GameObject star in uncollectedStars) {
			data.starsCollected [int.Parse (star.name.Substring (5)) - 1] = false;
			data.totalStarsCollected--;
			totalStars--;
		}
		
		bf = new BinaryFormatter ();
		file = File.Create (Application.persistentDataPath + "/" + level.ToString() +".dat");
		bf.Serialize (file, data);
		file.Close ();
		if (level > highestLevel)
			highestLevel++;
	}

	public void DeleteAllData(){
		highestLevel = -1;
		totalStars = 0;
		//Reset each level's data.
		for (int i = 0; i < NUM_OF_LEVELS; i++) {
			if (File.Exists (Application.persistentDataPath + "/" + i.ToString () + ".dat"))
				File.Delete(Application.persistentDataPath + "/" + i.ToString () + ".dat");
		}
	}

	public int GetLevelNum(){
		return UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex - 4;
	}
		
}
