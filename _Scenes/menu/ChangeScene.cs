using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public AudioClip bgmLvl1;
	public AudioClip bgmLvl7;
	private AudioClip musicToPlay;

	/* Wrapper function to start appropriate music for that scene for first time selecting. */
	public void changeSceneFromSelection(int sceneToChangeTo){
		if (4 <= sceneToChangeTo && sceneToChangeTo <= 9) {
			musicToPlay = bgmLvl1;
		} 
		else if (10 <= sceneToChangeTo) {
			musicToPlay = bgmLvl7;
		}
		GameObject musicManager = GameObject.Find ("MusicManager");
		musicManager.GetComponent<AudioSource> ().clip = musicToPlay;
		musicManager.GetComponent<AudioSource> ().Play ();
		changeToScene(sceneToChangeTo);
	}

	public void changeToScene(int sceneToChangeTo){
		SceneManager.LoadSceneAsync (sceneToChangeTo);
	}
}