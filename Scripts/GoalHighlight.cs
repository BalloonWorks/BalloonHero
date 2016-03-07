using UnityEngine;
using System.Collections;

public class GoalHighlight : MonoBehaviour {
    
    private bool colourChanged = false;
    private double interval = 0.25;
    private double nextTime = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextTime)
        {

            changeColor();

            nextTime += interval;

        }
    }

    void changeColor()
    {
        if (colourChanged == false)
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
            colourChanged = true;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
            colourChanged = false;
        }
    }
}
