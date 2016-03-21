using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class LookAtTarget : MonoBehaviour {

	/// <summary>
	/// The target to look at.
	/// </summary>
	public Transform target;


	/// <summary>
	/// Rotation speed.
	/// </summary>
	public float speed;
	
	// Update is called once per frame
	void Update () {
		transform.LookAt 
		(new Vector3(
			Util.percentDiff(transform.position.x,target.position.x,speed),
			Util.percentDiff(transform.position.y,target.position.y,speed),
			Util.percentDiff(transform.position.z,target.position.z,speed))
		);
	}
}
