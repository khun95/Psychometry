using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadClear : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        KeypadInputController.password = "";
        GetComponent<Playsound>().Clicky();
    }
}
