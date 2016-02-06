using UnityEngine;
using System.Collections;

public class DestroyOnClick : MonoBehaviour {

	void OnMouseDown(){
		Destroy (gameObject);
	}
}
