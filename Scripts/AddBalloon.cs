using UnityEngine;
using System.Collections;

public class AddBalloon : MonoBehaviour {
	public Rigidbody2D self;
	public Transform balloon;
	public Transform spawnPoint;
	public Transform connectPoint;
	public GameObject highlight;
	public float upForce = -3;
	public float scale;

	public void AddNewBalloon(){
		Transform newBalloon = Instantiate (balloon);
		newBalloon.GetComponent<SpriteRenderer> ().sortingLayerName = "Forground";
		newBalloon.GetComponent<Rigidbody2D> ().gravityScale = upForce;
		newBalloon.localScale = new Vector3 (scale, scale, 1);
		newBalloon.position = spawnPoint.position;
		SpringJoint2D newBalloonSpring = newBalloon.GetComponent<SpringJoint2D> ();
		newBalloonSpring.connectedBody = self;
		newBalloonSpring.anchor = new Vector2(-0.8f,0);
		newBalloonSpring.connectedAnchor = connectPoint.localPosition;
		newBalloonSpring.autoConfigureConnectedAnchor = true;
		newBalloonSpring.autoConfigureDistance = true;
	}
}
