using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondRightRoomLockController : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool draw1 = false;
    public static bool draw2 = false;
    public static bool draw3 = false;
    public static bool draw4 = false;
    public static bool draw5 = false;
    public static bool draw6 = false;
    public static bool draw7 = false;
    AudioSource audioSource;
    public GameObject doors;

    public bool isFirst = true;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isFirst)
        {
            if (draw1 && draw2 && draw3 && draw4 && draw5 && draw6 && !draw7)
            {
                //Debug.Log("Clear");
                doors.GetComponent<LockedDoor>().enabled = false;
                doors.GetComponent<DoorObjectControllers>().enabled = true;
                audioSource.Play();
                isFirst = false;
            }
        }
        
    }
}

