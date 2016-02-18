using UnityEngine;
using System.Collections;

public class gameOver : MonoBehaviour {

	Animator anim;

	void Start()
	{
		anim = GameObject.Find("Canvas").GetComponent<Animator>();
	}

	/* If the box touches the floor, game is over*/
	void OnTriggerEnter2D(Collider2D obj){
		if (obj.gameObject.name == "box") {
			Destroy (obj.gameObject);
			//and switch to game over screen
			anim.SetTrigger("GameOver");
			Debug.Log("Game Over");
		}
	}
}
