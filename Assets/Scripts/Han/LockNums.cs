using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockNums : MonoBehaviour
{
    // Start is called before the first frame update
    public int lockNums;
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
    }
    public void ButtonColorChange()
    {
        if (gameObject.GetComponent<MeshRenderer>().material.color == Color.black)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.black;
        }
    }
    public void PadNumClick(ref bool nums)
    {
        if (nums)
        {
            nums = false;
        }
        else
        {
            nums = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            switch (lockNums)
            {
                case 1:
                    PadNumClick(ref SecondLeftRoomLockController.num1);
                    ButtonColorChange();
                    return;
                case 2:
                    PadNumClick(ref SecondLeftRoomLockController.num2);
                    ButtonColorChange();
                    return;
                case 3:
                    PadNumClick(ref SecondLeftRoomLockController.num3);
                    ButtonColorChange();
                    return;
                case 4:
                    PadNumClick(ref SecondLeftRoomLockController.num4);
                    ButtonColorChange();
                    return;
                case 5:
                    PadNumClick(ref SecondLeftRoomLockController.num5);
                    ButtonColorChange();
                    return;
                case 6:
                    PadNumClick(ref SecondLeftRoomLockController.num6);
                    ButtonColorChange();
                    return;
                case 7:
                    PadNumClick(ref SecondLeftRoomLockController.num7);
                    ButtonColorChange();
                    return;
                case 8:
                    PadNumClick(ref SecondLeftRoomLockController.num8);
                    ButtonColorChange();
                    return;
                default:
                    break;
            }


        }
    }
}
