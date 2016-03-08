using UnityEngine;
using System.Collections;

public class FollowingCamera : MonoBehaviour
{
    public Transform target;
    public float xOffset;
    public float yOffset;
    public float zOffset;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (target && target.transform.position.y > -1.5 && target.transform.position.y < 15)
        {
            this.transform.position = new Vector3(0,
                                          target.transform.position.y + yOffset,
                                          -15);
        }
    }
}