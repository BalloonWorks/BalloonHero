using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class forceGameEnd : MonoBehaviour {
	
	public AudioClip bgm; //music to be played when returning to title screen

	public void backToMenu(){
		SceneManager.LoadSceneAsync (0);  //start screen has to be scene 0
		GameObject musicManager = GameObject.Find ("MusicManager");
		musicManager.GetComponent<AudioSource> ().clip = bgm;
		musicManager.GetComponent<AudioSource> ().Play ();
	}
}
