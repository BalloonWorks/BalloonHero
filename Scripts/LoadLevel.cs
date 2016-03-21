using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		ArrayList starsCollected = World.data.GetStarsObtained (World.data.GetLevelNum());
		foreach (int star in starsCollected)
			UnityEngine.GameObject.Destroy(UnityEngine.GameObject.Find("Stars" + (star + 1).ToString()));
		globalVariables.starsCount = starsCollected.Count;
		if (World.data.STARS_IN_LEVEL [World.data.GetLevelNum()] == 0)
			globalVariables.countText.text = "";
		else
			globalVariables.countText.text = "Stars Count: " + globalVariables.starsCount.ToString() + "/" + World.data.STARS_IN_LEVEL[World.data.GetLevelNum()].ToString();
	}
}
