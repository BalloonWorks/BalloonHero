using UnityEngine;
using System.Collections;

public class Float : MonoBehaviour {

	/// <summary>
	/// The max vertical speed.
	/// </summary>
	public float maxSpeed;

	/// <summary>
	/// The force to apply each update.
	/// </summary>
	public float force;

	/// <summary>
	/// Who to apply the force to.
	/// </summary>
	public Rigidbody2D target;

	void FixedUpdate () {
		if (target.velocity.y < maxSpeed)
			target.AddForce (new Vector2 (0, force));
	}
}
