using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour {
	/*Add this script to GameOverCanvas */

	public AudioClip bgm; //music to be played when returning to title screen

	// Update is called once per frame
	void Update () {
		if (globalVariables.gameEnded && Input.GetKeyDown (KeyCode.Mouse0)) {
			gameObject.SetActive (false);
			globalVariables.gameEnded = false;
			SceneManager.LoadSceneAsync (0);  //start screen has to be scene 0
			GameObject musicManager = GameObject.Find ("MusicManager");
			musicManager.GetComponent<AudioSource> ().clip = bgm;
			musicManager.GetComponent<AudioSource> ().Play ();
		} 
		//else if (Input.GetKeyDown (KeyCode.R)) { //restart the current level
		//	UnityEngine.SceneManagement.SceneManager.LoadScene (
		//		UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
		//}
	}
}
