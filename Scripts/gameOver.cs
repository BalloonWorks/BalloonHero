using UnityEngine;
using System.Collections;

public class gameOver : MonoBehaviour {

	public GameObject animObj;

	void Start()
	{
		//animObj = GameObject.Find("Canvas");
	}

	/* If the box touches the floor, game is over*/
	void OnTriggerEnter2D(Collider2D obj){
		if (obj.gameObject.name == "box") {
			Destroy (obj.gameObject);
			//and switch to game over screen
            animObj.SetActive(true);
            Animator anim = animObj.GetComponent<Animator>();
			anim.SetTrigger("GameOver");
			Debug.Log("Game Over");
            globalVariables.starsCount = 0;
		}
	}
}
