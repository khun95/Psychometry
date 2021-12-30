using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ControllerTest : MonoBehaviour
{ 
	protected float reachRange = 2f;

	protected Animator anim;
	protected GameObject player;
	protected const string animBoolName = "isOpen_Obj";

	protected bool playerEntered;
	protected bool showInteractMsg;
	protected GUIStyle guiStyle;
	protected string msg;

	protected int rayLayerMask;

	public Action updateAction;

	protected void Start()
	{
		//Initialize moveDrawController if script is enabled.
		player = GameObject.FindGameObjectWithTag("Hand");
		

		//create AnimatorOverrideController to re-use animationController for sliding draws.
		anim = GetComponent<Animator>();
		//Debug.Log(anim);
		anim.enabled = false;  //disable animation states by default.  

		//the layer used to mask raycast for interactable objects only
		LayerMask iRayLM = LayerMask.NameToLayer("InteractRaycast");
		rayLayerMask = 1 << iRayLM.value;

		//setup GUI style settings for user prompts
		setupGui();

	}

	protected void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Hand")        //player has collided with trigger
		{
			Debug.Log("trigger enter");
			playerEntered = true;
		}
	}

	protected void OnTriggerExit(Collider other)
	{
		if (other.tag == "Hand")        //player has exited trigger
		{
			Debug.Log("trigger exit");
			playerEntered = false;
			//hide interact message as player may not have been looking at object when they left
			showInteractMsg = false;
			GameTextManager.TextOnCanvas(showInteractMsg, msg);
		}
	}



	protected void Update()
	{
		Vector3 rayOrigin = player.transform.position;
		Debug.DrawRay(rayOrigin, -player.transform.forward * reachRange, Color.red);
		if (playerEntered)
		{

			//center point of viewport in World space.
			RaycastHit hit;

			//if raycast hits a collider on the rayLayerMask
			if (Physics.Raycast(rayOrigin, -player.transform.forward, out hit, reachRange, rayLayerMask))
			{
				updateAction();
			}
			else
			{
				showInteractMsg = false;
			}
		}

	}

	//is current gameObject equal to the gameObject of other.  check its parents
	protected bool isEqualToParent(Collider other, out AnimableObject draw)
    {
        draw = null;
        bool rtnVal = false;
        try
        {
            int maxWalk = 6;
            draw = other.GetComponent<AnimableObject>();
            GameObject currentGO = other.gameObject;
            for (int i = 0; i < maxWalk; i++)
            {
                if (currentGO.Equals(this.gameObject))
                {
                    rtnVal = true;
                    if (draw == null)
                        draw = currentGO.GetComponentInParent<AnimableObject>();

                    break;          //exit loop early.
                }

                //not equal to if reached this far in loop. move to parent if exists.
                if (currentGO.transform.parent != null)     //is there a parent
                {
                    currentGO = currentGO.transform.parent.gameObject;
                }
            }
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }

        return rtnVal;

    }


    #region GUI Config

    //configure the style of the GUI
    protected void setupGui()
	{
		guiStyle = new GUIStyle();
		guiStyle.fontSize = 16;
		guiStyle.fontStyle = FontStyle.Bold;
		guiStyle.normal.textColor = Color.white;
		msg = "Open";
	}

	protected string getGuiMsg(bool isOpen)
	{
		string rtnVal;
		if (isOpen)
		{
			rtnVal = "Close";
		}
		else
		{
			rtnVal = "Open";
		}

		return rtnVal;
	}

	//void OnGUI()
	//{
	//	if (showInteractMsg)  //show on-screen prompts to user for guide.
	//	{
	//		GUI.Label(new Rect (50,Screen.height - 50,200,50), msg,guiStyle);
	//	}
	//}		
	//End of GUI Config --------------
	#endregion
}

