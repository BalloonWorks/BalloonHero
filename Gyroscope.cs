using UnityEngine;
using System.Collections;

public class Gyroscope : MonoBehaviour {

	public float target;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3(0,0,0.1f*(target - transform.localEulerAngles.z)));
	}
}
