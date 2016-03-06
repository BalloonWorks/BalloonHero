using UnityEngine;
using System.Collections;

public class Kite : MonoBehaviour {

    public Rigidbody2D self;
    public float lightness;
 

	// Use this for initialization
	void Start () {
       
	}

    void FixedUpdate()
    {
        if (Mathf.Abs(self.velocity.x) < Mathf.Abs(World.data.WindSpeed()) || self.velocity.x * World.data.WindSpeed() < 0)
            self.AddForce(new Vector2(World.data.WindSpeed() * lightness, 0));
            transform.Rotate(0, 10*Time.deltaTime, 0);

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "balloon")
        {
            Destroy(col.gameObject);
        }
    }
}
