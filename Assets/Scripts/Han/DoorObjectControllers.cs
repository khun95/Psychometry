using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DoorObjectControllers : ControllerTest 
{

    private new  void Start()
    {
        base.Start();
		updateAction += () =>
		{
			showInteractMsg = true;
			string animBoolNameNum = animBoolName;
			bool isOpen = anim.GetBool(animBoolNameNum);    //need current state for message.
			msg = getGuiMsg(isOpen);
			GameTextManager.TextOnCanvas(showInteractMsg, msg);
			if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
			{
				anim.enabled = true;
				AudioSoundEvent.DoorOpenClose(anim.GetBool(animBoolNameNum));
				anim.SetBool(animBoolNameNum, !isOpen);
				msg = getGuiMsg(!isOpen);
			}
		};
    }


}
