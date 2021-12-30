using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LockedDoor : MonoBehaviour
{
    // Start is called before the first frame update
    public int msgNum = 0;
    public GameObject door;
    public static TextMeshProUGUI gameText;
    public TextMeshProUGUI temp;
    void Start()
    {
        gameText = temp;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            if (msgNum == 0)
            {

                gameText.text = "Door Locked. Solve the Puzzle";
            }
            else
            {
                gameText.text = "Door Locked.";
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
