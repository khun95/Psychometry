using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestDrawCheckController : MonoBehaviour
{
    public GameObject chest;
    public Animator anim;
    AnimableObject moveableObject;
    public int objectNum;
    // Start is called before the first frame update
    void Start()
    {
        anim = chest.GetComponent<Animator>();
        moveableObject = GetComponent<AnimableObject>();
        objectNum = moveableObject.objectNumber;
        
    }

    // Update is called once per frame
    void Update()
    { 
        switch (objectNum)
        {
            case 1:
                SecondRightRoomLockController.draw1 = anim.GetBool("isOpen_Obj_1");
                return;
            case 2:
                SecondRightRoomLockController.draw2 = anim.GetBool("isOpen_Obj_2");
                return;
            case 3:
                SecondRightRoomLockController.draw3 = anim.GetBool("isOpen_Obj_3");
                return;
            case 4:
                SecondRightRoomLockController.draw4 = anim.GetBool("isOpen_Obj_4");
                return;
            case 5:
                SecondRightRoomLockController.draw5 = anim.GetBool("isOpen_Obj_5");
                return;
            case 6:
                SecondRightRoomLockController.draw6 = anim.GetBool("isOpen_Obj_6");
                return;
            case 7:
                SecondRightRoomLockController.draw7 = anim.GetBool("isOpen_Obj_7");
                return;
            default:
                break;
        }
    }
}
