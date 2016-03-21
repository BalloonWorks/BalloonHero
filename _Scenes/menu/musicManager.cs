using UnityEngine;
using System.Collections;

public class musicManager : MonoBehaviour {
	
	private static musicManager instance = null;

	public static musicManager Instance {
		get { return instance; }

	}

	/* Just to check where the stored files go. */
	void Start(){
		Debug.Log (Application.persistentDataPath);
	}

	void Awake(){
		if (instance != null && instance != this) {
			Destroy (this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad (this.gameObject);
	}
}
