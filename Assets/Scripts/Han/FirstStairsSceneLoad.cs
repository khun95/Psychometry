using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FirstStairsSceneLoad : MonoBehaviour
{
    public GameObject SplashObj;               //�ǳڿ�����Ʈ
    public Image image;                            //�ǳ� �̹���
    bool isTriggerEnter = false;
    bool checkbool;
    void Start()
    {
        SplashObj = GameObject.FindGameObjectWithTag("Panel");                         //��ũ��Ʈ ������ ������Ʈ
        image = SplashObj.GetComponent<Image>();
        //SplashObj.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            Debug.Log("Ʈ����");
            isTriggerEnter = true;

        }
    }

    IEnumerator FadeIn()
    {
        SplashObj.SetActive(true);
        Color color = image.color;
        color.a = 0;
        checkbool = false;
        while (checkbool == false)
        {

            color.a += Time.deltaTime * 0.75f;

            image.color = color;

            if (image.color.a >= 1)
            {
                checkbool = true;
                GameSceneManager.LoadScene();
            }


            yield return null;
            Debug.Log("��ο����� �� " + color.a);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isTriggerEnter)
        {
            StartCoroutine(FadeIn());
        }
    }
}
