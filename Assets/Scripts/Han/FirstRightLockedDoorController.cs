using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FirstRightLockedDoorController : MonoBehaviour
{

    public static bool key1 = false;
    public bool isDoor1 = false;
    public GameObject door1;
    public static TextMeshProUGUI gameText;
    public TextMeshProUGUI temp;
    // Start is called before the first frame update
    void Start()
    {
        gameText = temp;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Hand")
        {
            if (key1)
            {
                gameText.text = "Press Space to Unlock Doors";
                isDoor1 = true;
            }
            else
            {
                gameText.text = "You don't have keys";
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        gameText.text = "";
    }
        // Update is called once per frame
        void Update()
    {
        if (isDoor1)
        {
            if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
            {
                AudioSoundEvent.DoorUnlock();
                door1.GetComponent<DoorObjectControllers>().enabled = true;
                gameText.text = "";
                GetComponent<FirstRightLockedDoorController>().enabled = false;
            }
        }
    }
}
