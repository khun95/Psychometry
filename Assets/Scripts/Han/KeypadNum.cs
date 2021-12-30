using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadNum : MonoBehaviour
{
    // Start is called before the first frame update
    public string keypadNums = "0";
    private GameObject player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Hand");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            GetComponent<Playsound>().Clicky();
            KeypadInputController.password += keypadNums;
            Debug.Log("----------------------------");
            Debug.Log(KeypadInputController.password);
            Debug.Log("----------------------------");
        }
    }
}
