using UnityEngine;
using System.Collections;

public class newBGM : MonoBehaviour {

	/*Must attach this script to a game object named "BGM" */

	public AudioClip bgm;

	void Awake(){
		GameObject musicManager = GameObject.Find ("MusicManager");
		musicManager.GetComponent<AudioSource>().clip = bgm;
		musicManager.GetComponent<AudioSource>().Play ();
	}
}
