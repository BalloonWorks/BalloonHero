using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class globalVariables : MonoBehaviour {

    public static int starsCount;
	public static int totalStars;
    public static Text countText;
	public static bool gameEnded = false;


	void Start()
    {
        countText = GameObject.Find("StarsCountText").GetComponent<Text>();
		totalStars = World.data.totalStars;
    }
}
