using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StarsCount1 : MonoBehaviour
{

    void Start()
    {
        try
        {
            string starsCount = globalVariables.starsCount.ToString();
            globalVariables.countText.text = "Stars Count: " + starsCount + "/1";
        }
        catch
        {

        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "star")
        {
            Destroy(col.gameObject);
            globalVariables.starsCount += 1;
            globalVariables.countText.text = "Stars Count: " + globalVariables.starsCount.ToString() + "/1";
        }
    }
}