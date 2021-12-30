using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SecondDoorShowPasswordController : MonoBehaviour
{
    private bool isShowing = true;
    public TextMeshProUGUI password1;
    public TextMeshProUGUI password2;
    public TextMeshProUGUI password3;
    public TextMeshProUGUI password4;

    public List<TextMeshProUGUI> passwords;
    bool isTouch = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    IEnumerator ShowPassword()
    {
        if (isShowing)
        {
            isShowing = false;


            #region 코루틴 반복 제어
            /*
            isShowing = false;

            for(int i=0;i<passwords.Count;i++)
            {
                yield return new WaitForSeconds(0.5f);
                passwords[i].gameObject.SetActive(true);
                if(i > 0)
                    passwords[i-1].gameObject.SetActive(false);
            }*/
            #endregion

            isShowing = true;
            isTouch = false;

            password1.text = "6";
            yield return new WaitForSeconds(0.5f);
            password1.text = "";
            password2.text = "2";
            yield return new WaitForSeconds(0.5f);
            password2.text = "";
            password3.text = "6";
            yield return new WaitForSeconds(0.5f);
            password3.text = "";
            password4.text = "4";
            yield return new WaitForSeconds(0.5f);
            password4.text = "";
            isShowing = true;
            isTouch = false;
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Hand")
        {
            GameTextManager.SkillTextOnCanvas(true);
            isTouch = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        GameTextManager.SkillTextOnCanvas(false);
        isTouch = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (isTouch)
        {
            if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            {
                GameTextManager.SkillTextOnCanvas(false);
                StartCoroutine(ShowPassword());
            }
        }

    }
}
