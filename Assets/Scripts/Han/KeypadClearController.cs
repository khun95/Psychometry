using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class KeypadClearController : MonoBehaviour
{

	public GameObject doorlocks;
	public GameObject doors;
	public Canvas keypadCanvas;

	private GameObject player;
	private int rayLayerMask;

	private void Awake()
    {
		player = GameObject.FindGameObjectWithTag("Hand");
		
	}
    public void KeypadClear()
	{
		//Debug.Log("click");
		AudioSoundEvent.KeyPadUnlock();
		doorlocks.GetComponent<SecondDoorShowPasswordController>().enabled = false;
		doors.GetComponent<SecondDoorKeypadController>().enabled = false;
		keypadCanvas.gameObject.SetActive(false);
		doors.GetComponent<DoorObjectControllers>().enabled = true;

	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Hand")
        {
			//Debug.Log("click");
			if (KeypadInputController.isCorrect)
			{
				Debug.Log("Correct");
				KeypadClear();
			}
            else
            {
				AudioSoundEvent.KeyPadUnlockFailure();
				Debug.Log("inCorrect");
			}
		}
    }
}

