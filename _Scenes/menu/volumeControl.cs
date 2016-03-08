using UnityEngine;
using System.Collections;

public class volumeControl : MonoBehaviour {

	GameObject musicManager;

	void Awake(){
		musicManager = GameObject.Find ("MusicManager");
		//restore current sound settings
		if (musicManager.GetComponent<AudioSource> ().mute) {
			GameObject.Find ("MuteButton").GetComponent<UnityEngine.UI.Toggle>().isOn = true;
			muteUnmute ();  //toggle will unmute so toggle it again
		}
		float currentVolume = musicManager.GetComponent<AudioSource> ().volume;
		GameObject.Find ("bgmSlider").GetComponent<UnityEngine.UI.Slider> ().value = currentVolume;
	}

	public void muteUnmute(){
		musicManager.GetComponent<AudioSource> ().mute = !(musicManager.GetComponent<AudioSource> ().mute);
	}

	public void changeVolume(){
		float newVolume = GameObject.Find ("bgmSlider").GetComponent<UnityEngine.UI.Slider> ().value;
		musicManager.GetComponent<AudioSource> ().volume = newVolume;
	}
		
}