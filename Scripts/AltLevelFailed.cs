using UnityEngine;
using System.Collections;

public class AltLevelFailed : MonoBehaviour
{

	public GameObject levelFailedPanel;

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "balloonGift") {
			levelFailedPanel.SetActive (true);
			Destroy (col.gameObject);
		}
	}
}

