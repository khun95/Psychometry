using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PantryKeypadController : MonoBehaviour
{
	public float reachRange = 1.8f;

	public Camera fpsCam;
	private GameObject player;

	private bool playerEntered;
	private bool showInteractMsg;
	private GUIStyle guiStyle;
	private string msg;
	public Canvas numLockCanvas;
	bool isOpen = true;
	private int rayLayerMask;


	void Start()
	{
		//Initialize moveDrawController if script is enabled.
		player = GameObject.FindGameObjectWithTag("Hand");

		fpsCam = Camera.main;
		if (fpsCam == null) //a reference to Camera is required for rayasts
		{
			Debug.LogError("A camera tagged 'MainCamera' is missing.");
		}

		//create AnimatorOverrideController to re-use animationController for sliding draws.

		//the layer used to mask raycast for interactable objects only
		LayerMask iRayLM = LayerMask.NameToLayer("InteractRaycast");
		rayLayerMask = 1 << iRayLM.value;

		//setup GUI style settings for user prompts
		setupGui();

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Hand")     //player has collided with trigger
		{
			Debug.Log("trigger enter");
			playerEntered = true;

		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Hand")     //player has exited trigger
		{
			Debug.Log("trigger exit");
			playerEntered = false;
			//hide interact message as player may not have been looking at object when they left
			showInteractMsg = false;
			GameTextManager.TextOnCanvas(showInteractMsg, msg);
		}
	}



	void Update()
	{
		if (playerEntered)
		{

			//center point of viewport in World space.
			Vector3 rayOrigin = player.transform.position;
			Debug.DrawRay(rayOrigin, -player.transform.forward * reachRange, Color.red);
			RaycastHit hit;

			//if raycast hits a collider on the rayLayerMask
			//Debug.DrawRay(rayOrigin, fpsCam.transform.forward * reachRange, Color.red);
			if (Physics.Raycast(rayOrigin, -player.transform.forward, out hit, reachRange, rayLayerMask))
			{
				showInteractMsg = true;
				msg = getGuiMsg(isOpen);
				GameTextManager.TextOnCanvas(showInteractMsg, msg);
				if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
				{
					numLockCanvas.gameObject.SetActive(isOpen);
					KeypadInputController.password = "";
					isOpen = !isOpen;
					msg = getGuiMsg(isOpen);
				}
			}
			else
			{
				showInteractMsg = false;
			}
		}

	}


	#region GUI Config

	//configure the style of the GUI
	private void setupGui()
	{
		guiStyle = new GUIStyle();
		guiStyle.fontSize = 16;
		guiStyle.fontStyle = FontStyle.Bold;
		guiStyle.normal.textColor = Color.white;
		msg = "Open";
	}

	private string getGuiMsg(bool isOpen)
	{
		string rtnVal;
		if (isOpen)
		{
			rtnVal = "OpenKeypad";
		}
		else
		{
			rtnVal = "CloseKeypad";
		}

		return rtnVal;
	}

	//void OnGUI()
	//{
	//	if (showInteractMsg)  //show on-screen prompts to user for guide.
	//	{
	//		GUI.Label(new Rect(50, Screen.height - 50, 200, 50), msg, guiStyle);
	//	}
	//}
	//End of GUI Config --------------
	#endregion
}
