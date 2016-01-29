using UnityEngine;
using System.Collections;

/// <summary>
/// World: Stores infomation pertaining to the world that other
/// classes require.
/// </summary>
public class World : MonoBehaviour {

	/// <summary>
	/// Points to the instance of the world, used to get
	/// data about the world.
	/// </summary>
	public static World data;//Points to the instance of the world

	/// <summary>
	/// The current global wind speed.
	/// </summary>
	private float windSpeed;

	/// <summary>
	/// Destroy this instance if one exists, otherwise
	/// intializes it.
	/// </summary>
	void Start () {
		//If there is no World...
		if (data == null) {
			//Set the static instance to this object
			data = this;
		} 
		//Otherwise...
		else {
			//An instance exists, so destroy it
			Destroy (this.gameObject);
		}
	}
	
	/// <summary>
	/// Captures any revelant user input and update fields. accordingly.
	/// </summary>
	void Update () {
		windSpeed = Input.GetAxis ("Horizontal");
	}

	/// <summary>
	/// Get the global windspeed.
	/// </summary>
	/// <returns>The current windspeed.</returns>
	public float WindSpeed(){
		return 3*windSpeed;
	}
}
