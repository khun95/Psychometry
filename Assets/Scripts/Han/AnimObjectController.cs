using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnimObjectController : ControllerTest 
{
	private new void Start()
	{
		base.Start();
		/*updateAction += () =>
		{
			AnimableObject moveableObject = null;
			//is the object of the collider player is looking at the same as me?
			if (!isEqualToParent(hit.collider, out moveableObject))
			{   //it's not so return;
				return;
			}

			if (moveableObject != null)     //hit object must have MoveableDraw script attached
			{
				showInteractMsg = true;
				string animBoolNameNum = animBoolName + moveableObject.objectNumber.ToString();

				bool isOpen = anim.GetBool(animBoolNameNum);    //need current state for message.
				msg = getGuiMsg(isOpen);
				if (!GameTextManager.isFade)
				{
					GameTextManager.TextOnCanvas(showInteractMsg, msg);
				}
				if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
				{
					anim.enabled = true;
					AudioSoundEvent.DrawOpenClose(anim.GetBool(animBoolNameNum));
					anim.SetBool(animBoolNameNum, !isOpen);
					msg = getGuiMsg(!isOpen);
				}

			}
		};
	}*/
	}
}

