using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		ArrayList starsCollected = World.data.GetStarsObtained (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex - 2);
		foreach (int star in starsCollected) {
			UnityEngine.GameObject.Destroy(UnityEngine.GameObject.Find("Stars" + (star + 1).ToString()));
		}
	}
}
