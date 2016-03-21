using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {

	void Start(){
		for (int level = 1; level <= 10; level++) {
			if (World.data.GetStarsObtained(level-1).Count > 0) {
				Debug.Log (level);
				Debug.Log (World.data.GetStarsObtained (level-1).Count);
				highlightCollectedStars (level);
			}
		}
	}
	
	public void highlightCollectedStars(int level){
		int starsCollected = World.data.GetStarsObtained (level - 1).Count;
		for (int i = 1; i <= starsCollected; i++){
			GameObject star = GameObject.FindGameObjectWithTag("level" + level.ToString () + "star" + i.ToString());
			star.GetComponent<UnityEngine.UI.Image> ().color = Color.white;
		}
	}
}
