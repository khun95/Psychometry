using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoveControll : MonoBehaviour
{
    // Start is called before the first frame update
    bool isOpen = false;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        isOpen = anim.GetBool("isOpen_Obj");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isOpen)
            {
                anim.SetBool("isOpen_Obj", !isOpen);
                isOpen = !isOpen;
            }
            else
            {
                anim.SetBool("isOpen_Obj", !isOpen);
                isOpen = !isOpen;
            }
        }
    }
}
