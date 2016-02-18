using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class House : MonoBehaviour {

	Animator anim;
	public GameObject levelCompletedPanel;
	Text gameOverText;

	// Use this for initialization
	void Start () {
		anim = GameObject.Find("Canvas").GetComponent<Animator>();
		gameOverText = GameObject.Find("GameOverText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "balloonGift")
        {
			//and switch to game over screen
			/*gameOverText.text = "Win!";
			anim.SetTrigger("GameOver");
			Debug.Log("Game Over");*/
			levelCompletedPanel.SetActive (true);
            Destroy(col.gameObject);
        }
    }
}
