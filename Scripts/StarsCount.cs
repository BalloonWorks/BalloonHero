using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StarsCount : MonoBehaviour
{
    void Start()
    {
        globalVariables.countText.text = "Stars Count: " + globalVariables.starsCount.ToString() + "/3";
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "star")
        {
            Destroy(col.gameObject);
            globalVariables.starsCount += 1;
            globalVariables.countText.text = "Stars Count: " + globalVariables.starsCount.ToString() + "/3";
        }
    }
}