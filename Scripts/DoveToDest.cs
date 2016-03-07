using UnityEngine;
using System.Collections;

public class DoveToDest : MonoBehaviour {

    public float horizentalSpeed;
    public GameObject attach;
    public GameObject dest;
    public GameObject finaldest;
    //public Vector3 tempPosition;
    public int x;
    Animator anim;
    private bool passed = false;
	// Use this for initialization
	void Start () {
        //tempPosition = transform.position;
        anim = GetComponent<Animator>();
        x = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        

        if (!passed)
        {
            transform.position = Vector3.Lerp(transform.position, dest.transform.position, Time.deltaTime * horizentalSpeed);
        }
        else
        {
            //x help that dove stand there for a while for transition
            ++x;
            if (x > 70)
            {
                attach.SetActive(true);
                transform.position = Vector3.Lerp(transform.position, finaldest.transform.position, Time.deltaTime * horizentalSpeed);
            }
        }


	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "transfer")
        {
            anim.SetTrigger("reach");
            passed = true;
            
        }
    }
}



