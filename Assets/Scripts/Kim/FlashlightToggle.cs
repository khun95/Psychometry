using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightToggle : MonoBehaviour
{
    public GameObject lightGO;
    private bool isOn = true;
    bool isKinematic;
    void Start()
    {
        lightGO.SetActive(isOn);
        isKinematic = gameObject.GetComponent<Rigidbody>().isKinematic;
    }
    void Update()
    {

        isKinematic = gameObject.GetComponent<Rigidbody>().isKinematic;
        if (isKinematic == true)
        {
            if (OVRInput.GetDown(OVRInput.Button.Four))
            {
                isOn = !isOn;
                lightGO.SetActive(isOn);
            
            }
        }
    }
}
