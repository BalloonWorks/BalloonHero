using UnityEngine;
using System.Collections;

public class AddBalloon : MonoBehaviour {
	public Rigidbody2D self;
	public Transform balloon;
	public Transform spawnPoint;
	public float scale;

	public Color normalColor;
	public Color highlightColor;
	public SpriteRenderer image;
	public float highlightTime;
	public bool highlighted;
	private float time;
	private bool increasing;
	void Start()
	{
		time = 0;
		increasing = true;
	}

	// Update is called once per frame
	void Update () {
		if (highlighted) {
			time = (increasing) ? Mathf.Min (time + Time.deltaTime, highlightTime) : Mathf.Max (time - Time.deltaTime, 0);
			if (time == highlightTime)
				increasing = false;
			else if (time == 0)
				increasing = true;
			image.material.color = Color.Lerp (normalColor, highlightColor, time / highlightTime);
		} else
			image.material.color = normalColor;
	}

	public void AddNewBalloon(){
		Transform newBalloon = Instantiate (balloon);
		newBalloon.localScale = new Vector3 (scale, scale, 1);
		newBalloon.position = spawnPoint.position;
		SpringJoint2D newBalloonSpring = newBalloon.GetComponent<SpringJoint2D> ();
		newBalloonSpring.connectedBody = self;
		newBalloonSpring.anchor = Vector2.zero;
		newBalloonSpring.connectedAnchor = Vector2.zero;
		newBalloonSpring.autoConfigureConnectedAnchor = true;
		newBalloonSpring.autoConfigureDistance = true;
	}
}
