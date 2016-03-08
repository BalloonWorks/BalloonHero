using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class globalVariables : MonoBehaviour {

    public static int starsCount;
    public static Text countText;
	public static bool gameEnded = false;


	void Start()
    {
        countText = GameObject.Find("StarsCountText").GetComponent<Text>();
    }
}
