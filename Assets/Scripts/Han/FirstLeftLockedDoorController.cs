using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FirstLeftLockedDoorController : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool key2 = false;
    public bool isDoor2 = false;
    public GameObject door2;
    public static TextMeshProUGUI gameText;
    public TextMeshProUGUI temp;
    // Start is called before the first frame update
    void Start()
    {
        gameText = temp;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            if (key2)
            {
                gameText.text = "Press Space to Unlock Doors";
                isDoor2 = true;
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
        //Debug.Log("key1 : " + key1);
        if (isDoor2)
        {
            if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
            {
                door2.GetComponent<DoorObjectControllers>().enabled = true;
                AudioSoundEvent.DoorUnlock();
                gameText.text = "";
                GetComponent<FirstLeftLockedDoorController>().enabled = false;
            }
        }
    }
}
