using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DoveCount : MonoBehaviour {

	public int doveCount;
	public Text countText;
	private Button doveButton;

	void Start () {
		doveCount = World.data.totalStars / 3;
		doveButton = UnityEngine.GameObject.Find ("DoveButton").GetComponent<Button> ();
		doveButton.interactable = doveCount > 0;
	}
	
	// Update is called once per frame
	void Update () {
		countText.text = doveCount.ToString ();
		doveButton.interactable = doveCount > 0;
	}
}
