using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class House : MonoBehaviour {

	public GameObject animObj;
	Text gameOverText;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "balloonGift")
        {
			//and switch to game over screen
            animObj.SetActive(true);
            gameOverText = GameObject.Find("GameOverText").GetComponent<Text>();
			gameOverText.text = "Win!";
			World.data.SaveLevelInfo (World.data.GetLevelNum());
            Animator anim = animObj.GetComponent<Animator>();
			anim.SetTrigger("GameOver");
			Debug.Log("Game Over");
            Destroy(col.gameObject);
            globalVariables.starsCount = 0;
			globalVariables.gameEnded = true;
			World.data.DeleteAllData ();
        }
    }
}
