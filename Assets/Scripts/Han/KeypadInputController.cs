using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadInputController : MonoBehaviour
{
    // Start is called before the first frame update
    public static string password;
    public string correctPassword;
    public static bool isCorrect = false;
    private void Awake()
    {
        password = "";  
    }
    private void Update()
    {
        Debug.Log("pass : " + password + " , " + "correct : " + correctPassword + " length" + password.Length);

        if (correctPassword == password)
        {
            isCorrect = true;      
        }
        else
        {
            isCorrect = false;
        }
    }


}
