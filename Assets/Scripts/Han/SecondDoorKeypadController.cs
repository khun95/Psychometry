using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SecondDoorKeypadController : MonoBehaviour
{
    // Start is called before the first frame update

    private float reachRange = 2f;

    private Camera fpsCam;
    public GameObject player;
    public GameObject doors;

    private bool playerEntered;
    private bool showInteractMsg;
    private GUIStyle guiStyle;
    private string msg;
    public Canvas keypadCanvas;
    private int rayLayerMask;


    bool isOpen = true;
    void Start()
    {
        //Initialize moveDrawController if script is enabled.
        player = GameObject.FindGameObjectWithTag("Hand");
        fpsCam = Camera.main;
        //doors.GetComponent<BoxCollider>().enabled = false;
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
            //keypadCanvas.gameObject.SetActive(false);
            Debug.Log("trigger exit");
            playerEntered = false;
            //hide interact message as player may not have been looking at object when they left
            showInteractMsg = false;
            GameTextManager.TextOnCanvas(showInteractMsg, msg);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 rayOrigin = player.transform.position;
        Debug.DrawRay(rayOrigin, -player.transform.forward * reachRange, Color.red);
        //Debug.Log("TEST" + playerEntered);
        if (playerEntered)
        {

            //center point of viewport in World space.
            RaycastHit hit;

            //if raycast hits a collider on the rayLayerMask
            if (Physics.Raycast(rayOrigin, -player.transform.forward, out hit, reachRange, rayLayerMask))
            {
                Debug.Log("레이 맞음 : " + hit.transform.name);
                showInteractMsg = true;
                msg = getGuiMsg(isOpen);
                GameTextManager.TextOnCanvas(showInteractMsg, msg);
                if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
                {
                    Debug.Log("트리거");
                    keypadCanvas.gameObject.SetActive(isOpen);
                    KeypadInputController.password = "";
                    isOpen = !isOpen;
                    msg = getGuiMsg(isOpen);
                }
            }
            else
            {
                //keypadCanvas.gameObject.SetActive(!isOpen);
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
        msg = "OpenKeypad";
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
    //    if (showInteractMsg)  //show on-screen prompts to user for guide.
    //    {
    //        GUI.Label(new Rect(50, Screen.height - 50, 200, 50), msg, guiStyle);
    //    }
    //}
    //End of GUI Config --------------
    #endregion
}
