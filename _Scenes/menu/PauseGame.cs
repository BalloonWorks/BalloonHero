using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {

	public GameObject pauseMenu;
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
			if (Time.timeScale == 1.0F) { //pause the game
				Time.timeScale = 0.0F;
				pauseMenu.SetActive (true);
			} else {  //un-pause
				Time.timeScale = 1.0F;
				pauseMenu.SetActive (false);
			}
		}
	
	}

	/* Use for other pausing methods. */
	public void pauseUnPause(){
		if (Time.timeScale == 1.0F) { //pause the game
			Time.timeScale = 0.0F;
			pauseMenu.SetActive (true);
		} else {  //un-pause
			Time.timeScale = 1.0F;
			pauseMenu.SetActive (false);
		}
	}
}
