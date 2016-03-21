using UnityEngine;
using System.Collections;

public class Spike : MonoBehaviour {
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "balloon")
        {
            Destroy(col.gameObject);
        }
    }
}
