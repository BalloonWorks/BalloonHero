using UnityEngine;
using System.Collections;

public class FollowCursor : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		Vector3 newPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		newPos.z = 0;
		newPos.x -= 1;
		transform.position = newPos;
	}
}
