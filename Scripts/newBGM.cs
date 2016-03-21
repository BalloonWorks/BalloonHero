using UnityEngine;
using System.Collections;

public class newBGM : MonoBehaviour {

	/*Must attach this script to a game object named "newBGM" */
	public AudioClip bgm;

	void Awake(){
		if (!World.restartedLevel) {
			GameObject musicManager = GameObject.Find ("MusicManager");
			musicManager.GetComponent<AudioSource> ().clip = bgm;
			musicManager.GetComponent<AudioSource> ().Play ();
		} 
		else { //restarted a level.. don't make bgm start from beginning again
			World.restartedLevel = false;
		}
	}
}
