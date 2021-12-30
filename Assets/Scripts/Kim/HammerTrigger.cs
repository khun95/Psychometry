using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerTrigger : MonoBehaviour
{
    public GameObject playerImage;
    private void OnTriggerEnter(Collider other)
    {
        if (playerImage != null)
            if (other.tag == "Hand")
            {

                playerImage.SetActive(true);
            }
    }
}
