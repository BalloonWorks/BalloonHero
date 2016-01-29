using UnityEngine;
using System.Collections;
using AssemblyCSharp;

/// <summary>
/// Updates an object to move in accordance with
/// the wind.
/// </summary>
public class WindForce : MonoBehaviour {
	/// <summary>
	/// The rigidbody to act on.
	/// </summary>
	public Rigidbody2D self;

	/// <summary>
	/// A value between 0 and 1. The higher it is, the more easily it adjusts to the wind.
	/// </summary>
	float lightness;

	/// <summary>
	/// Updates the velocity to be closer to the windspeed.
	/// </summary>
	void FixedUpdate () {
		if (Mathf.Abs(self.velocity.x) < Mathf.Abs(World.data.WindSpeed()) || self.velocity.x*World.data.WindSpeed() < 0)
		    self.AddForce (new Vector2 (World.data.WindSpeed(),0));
	}
}
