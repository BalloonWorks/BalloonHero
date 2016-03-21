using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StarsCount : MonoBehaviour
{
	private int totalStars;
	void Start() { //update to correct total number of stars in the level
		globalVariables.countText.text = "Stars Count: " + globalVariables.starsCount.ToString() + "/" + World.data.STARS_IN_LEVEL[World.data.GetLevelNum()].ToString();
		totalStars = World.data.totalStars;
		Debug.Log (totalStars);
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "star")
        {
            Destroy(col.gameObject);
            globalVariables.starsCount += 1;
			globalVariables.totalStars += 1;
			if (globalVariables.totalStars % 3 == 0)
				GameObject.FindObjectOfType<DoveCount> ().doveCount++;
			globalVariables.countText.text = "Stars Count: " + globalVariables.starsCount.ToString() + "/" + World.data.STARS_IN_LEVEL[World.data.GetLevelNum()].ToString();
        }
    }
}