using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class House : MonoBehaviour {

	public GameObject animObj;
	Text gameOverText;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "balloonGift")
        {
			//and switch to game over screen
            animObj.SetActive(true);
            gameOverText = GameObject.Find("GameOverText").GetComponent<Text>();
			gameOverText.text = "Win!";
			World.data.SaveLevelInfo (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex - 2);
            Animator anim = animObj.GetComponent<Animator>();
			anim.SetTrigger("GameOver");
			Debug.Log("Game Over");
            Destroy(col.gameObject);
            globalVariables.starsCount = 0;
        }
    }
}
