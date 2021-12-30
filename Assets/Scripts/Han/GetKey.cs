using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetKey : MonoBehaviour
{
    public int keyNum = 0;
    public static TextMeshProUGUI gameText;
    public TextMeshProUGUI temp;
    public bool isCol = false;
    // Start is called before the first frame update
    void Start()
    {
        gameText = temp;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCol)
        {
            if ((OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger)))
            {
                GameTextManager.SkillTextOnCanvas(false);
                AudioSoundEvent.PlaySiren();
                FirstRightLockedDoorController.key1 = true;
                StartCoroutine(Text());
                //GameTextManager.SkillTextOnCanvas(false);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Hand")
        {
            switch (keyNum)
            {
                case 1:
                    GetKey1();
                    //FirstRightLockedDoorController.key1 = true;
                    return;
                case 2:
                    FirstLeftLockedDoorController.key2 = true;
                    gameObject.SetActive(false);
                    return;
                default:
                    break;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //GameTextManager.SkillTextOnCanvas(false);
    }
    public void GetKey1()
    {
        GameTextManager.SkillTextOnCanvas(true);
        isCol = true;

    }

    IEnumerator Text()
    {
        gameText.text = "Police is aleady arrived.";
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
        gameText.text = " ";
        isCol = false;
    }
}
