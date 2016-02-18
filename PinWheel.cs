using UnityEngine;
using System.Collections;

public class PinWheel : MonoBehaviour {

	/// <summary>
	/// The maximum rotation speed.
	/// </summary>
	public float speed;

	/// <summary>
	/// The torque to apply each frame.
	/// </summary>
	public float torque;

	/// <summary>
	/// If the rotation reversed.
	/// </summary>
	public bool reversed;

	/// <summary>
	/// The object to affect.
	/// </summary>
	public Rigidbody2D self;

	// Update is called once per frame
	void FixedUpdate () {
		if (!reversed) 
		{
			if ((Mathf.Abs (self.angularVelocity) < Mathf.Abs (World.data.WindSpeed () * speed)) ||
			       (self.angularVelocity * World.data.WindSpeed () * speed < 0))
				self.AddTorque (torque * World.data.WindSpeed ());
		}
		else if ((Mathf.Abs(self.angularVelocity) < Mathf.Abs(World.data.WindSpeed () * speed)) ||
			(self.angularVelocity*World.data.WindSpeed () * speed > 0))
			self.AddTorque (-1*torque * World.data.WindSpeed ());
	}
}
