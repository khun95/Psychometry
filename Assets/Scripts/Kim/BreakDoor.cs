using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakDoor : MonoBehaviour
{
    int count = 3;
    public GameObject police;
    public GameObject door;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Hammer")
        {
            count--;
            SoundManager.instance.SfxClipPlay(3);
        }
    }
    private void Update()
    {
        if (count == 0)
        {
            //police.SetActive(true);
            Destroy(gameObject);
            door.GetComponent<DoorObjectControllers>().enabled = true;
        }
    }   
}
