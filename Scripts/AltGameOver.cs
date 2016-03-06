using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AltGameOver : MonoBehaviour {

	public GameObject levelCompletedPanel;
		
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "balloonGift")
		{
			levelCompletedPanel.SetActive (true);
			Destroy(col.gameObject);
		}
	}
}
