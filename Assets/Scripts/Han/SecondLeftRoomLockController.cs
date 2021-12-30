using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondLeftRoomLockController : MonoBehaviour
{
    public static bool num1 = false;
    public static bool num2 = false;
    public static bool num3 = false;
    public static bool num4 = false;
    public static bool num5 = false;
    public static bool num6 = false;
    public static bool num7 = false;
    public static bool num8 = false;
    public Canvas numLockCanvas;
    public GameObject pantry;
    public GameObject lockImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if(!num1 && num2 && num3 && !num4 && num5 && !num6 && num7 && num8)
        {
            Debug.Log("Clear");
            lockImage.SetActive(false);
            pantry.GetComponent<AnimObjectController>().enabled = true;
            pantry.GetComponent<PantryKeypadController>().enabled = false;
            numLockCanvas.gameObject.SetActive(false);
        }
    }
}
