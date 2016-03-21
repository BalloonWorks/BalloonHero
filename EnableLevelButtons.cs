using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnableLevelButtons : MonoBehaviour {

	public Button[] buttons;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < buttons.Length; i++)
			if (i <= World.data.highestLevel + 1)
				buttons [i].interactable = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
