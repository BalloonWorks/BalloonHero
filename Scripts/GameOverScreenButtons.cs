using UnityEngine;
using System.Collections;

public class GameOverScreenButtons : MonoBehaviour {
	
	public int nextLevelIndex;

	public void NextLevel()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene (nextLevelIndex);
	}

	public void ReplayLevel()
	{
		World.restartedLevel = true; //this is need by newBGM.cs
		UnityEngine.SceneManagement.SceneManager.LoadScene (
			UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex);
	}

	//TODO: Replace the bulid index here with the REAL main menu bulid index
	public void ReturnToMainMenu()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene (0);
	}
}
