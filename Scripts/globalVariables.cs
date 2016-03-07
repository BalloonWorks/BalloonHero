using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class globalVariables : MonoBehaviour {

    public static int starsCount=0;
    public static Text countText;


	void Start()
    {
        countText = GameObject.Find("StarsCountText").GetComponent<Text>();
    }
}
