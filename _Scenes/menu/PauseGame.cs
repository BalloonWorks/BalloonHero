using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {

	public GameObject pauseMenu;
	public GameObject settingsMenu;
	public GameObject UI;
	private bool insideGameSetting = false; //need to stop 'p' from activating while viewing settings

	void Update () {
		if (!insideGameSetting && Input.GetKeyDown (KeyCode.P)) {
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
			UI.SetActive (false);
		} else {  //un-pause
			Time.timeScale = 1.0F;
			pauseMenu.SetActive (false);
			UI.SetActive (true);
		}
	}

	public void showGameSettings(){
		if (Time.timeScale == 1.0F) { //pause the game
			Time.timeScale = 0.0F;
			settingsMenu.SetActive (true);
			insideGameSetting = true;
			UI.SetActive (false);
		} else {  //un-pause
			Time.timeScale = 1.0F;
			settingsMenu.SetActive (false);
			insideGameSetting = false;
			UI.SetActive (true);
		}
	}
}
