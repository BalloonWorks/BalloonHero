using UnityEngine;
using System.Collections;

public class FlyingBird : MonoBehaviour {

    public float horizentalSpeed;
    public float verticalSpeed;

    public float amplitude;
    public Vector3 tempPosition;
	// Use this for initialization
	void Start () {
        tempPosition = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (tempPosition.x < 12)
        {
            tempPosition.x += horizentalSpeed;
        }
        else
        {
            tempPosition.x = -12;
        }
        tempPosition.y = Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * amplitude;
        transform.position = tempPosition;
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "balloon")
        {
            Destroy(col.gameObject);
        }
    }
}
