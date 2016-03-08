using UnityEngine;
using System.Collections;

public class LightManager : MonoBehaviour {

    private Light lght;

    void Start()
    {
        lght = GetComponent<Light>();
    }


    void Update()
    {
        
        bool secEven = Mathf.FloorToInt(Time.time) % 2 == 0;
        lght.enabled = secEven;
    }

}
