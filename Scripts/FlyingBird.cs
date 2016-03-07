using UnityEngine;
using System.Collections;

public class FlyingBird : MonoBehaviour {

    public float horizentalSpeed;
    public float verticalSpeed;

    public float amplitude;
    public Vector3 tempPosition;
	public float yOffset;
	// Use this for initialization
	void Start () {
        tempPosition = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Mathf.Abs(tempPosition.x) < 13)
        {
            tempPosition.x += horizentalSpeed;
        }
        else
        {
			tempPosition.x = -12*Mathf.Sign(horizentalSpeed);
        }
        tempPosition.y = Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * amplitude + yOffset;
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
