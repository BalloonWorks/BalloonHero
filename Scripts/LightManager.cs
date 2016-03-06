using UnityEngine;
using System.Collections;

public class LightManager : MonoBehaviour {

    private Light light;

    void Start()
    {
        light = GetComponent<Light>();
    }


    void Update()
    {
        
        bool secEven = Mathf.FloorToInt(Time.time) % 2 == 0;
        light.enabled = secEven;
    }

}
