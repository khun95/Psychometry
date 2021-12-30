using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorpseTrigger : MonoBehaviour
{
    public GameObject slender;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            slender.SetActive(true);
    }
}
