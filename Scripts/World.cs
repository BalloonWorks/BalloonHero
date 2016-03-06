using UnityEngine;
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
	public static World data;//Points to the instance of the world
	public const int NUM_OF_LEVELS = 3;
	public readonly int[] STARS_IN_LEVEL = {0,0,3};
	public int highestLevel;
	public AudioSource music;
	/// <summary>
	/// The current global wind speed.
	/// </summary>
	private float windSpeed;

	/// <summary>
	/// Destroy this instance if one exists, otherwise
	/// intializes it.
	/// </summary>
	void Start () {
		//If there is no World...
		if (data == null) {
			//Set the static instance to this object
			data = this;
			music.Play ();
			windSpeed = 0;
			highestLevel = 0;
			while (File.Exists (Application.persistentDataPath + "/" + (highestLevel + 1).ToString () + ".dat"))
				highestLevel++;
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
		if (Input.GetKey (KeyCode.R))
			UnityEngine.SceneManagement.SceneManager.LoadScene (
				UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex);
		if (Input.GetKey (KeyCode.D))
			DeleteAllData ();
	}

	/// <summary>
	/// Get the global windspeed.
	/// </summary>
	/// <returns>The current windspeed.</returns>
	public float WindSpeed(){
		return 3*windSpeed;
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
		LevelInfo data = new LevelInfo ();
		GameObject[] uncollectedStars = UnityEngine.GameObject.FindGameObjectsWithTag ("star");
		data.starsCollected = new bool[STARS_IN_LEVEL[level]];

		for (int i = 0; i < data.starsCollected.Length; i++)
			data.starsCollected [i] = true;
		
		foreach (GameObject star in uncollectedStars)
			data.starsCollected[int.Parse(star.name.Substring (5)) - 1] = false;
		
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/" + level.ToString() +".dat");
		bf.Serialize (file, data);
		file.Close ();
		if (level > highestLevel)
			highestLevel++;
	}

	public void DeleteAllData(){
		highestLevel = 0;
		//Reset each level's data.
		for (int i = 0; i < NUM_OF_LEVELS; i++) {
			if (File.Exists (Application.persistentDataPath + "/" + i.ToString () + ".dat"))
				File.Delete(Application.persistentDataPath + "/" + i.ToString () + ".dat");
		}
	}
		
}
