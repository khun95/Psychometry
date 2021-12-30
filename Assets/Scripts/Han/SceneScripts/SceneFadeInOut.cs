using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneFadeInOut : MonoBehaviour
{
    public static GameObject SplashObj;               //�ǳڿ�����Ʈ
    public static Image image;                            //�ǳ� �̹���
    public static bool checkbool = false;     //���� ���� ���� ����

    IEnumerator stop;
    void Awake()
    {
        SplashObj = GameObject.FindGameObjectWithTag("Panel");                         //��ũ��Ʈ ������ ������Ʈ
        image = SplashObj.GetComponent<Image>();    //�ǳڿ�����Ʈ�� �̹��� ����
        stop = FadeOut();
    }


    void Update()
    {
        StartCoroutine(stop);                        //�ڷ�ƾ    //�ǳ� ���� ����
        if (checkbool)                                            //���� checkbool �� ���̸�
        {
            StopCoroutine(stop);
            //SplashObj.SetActive(false);                       //�ǳ� �ı�, ����
        }
    }
    IEnumerator FadeOut()
    {
        Color color = image.color;
        color.a = 1;
        checkbool = false;
        while (checkbool == false)
        {
            Debug.Log("Out");
            color.a -= Time.deltaTime * 0.5f;

            image.color = color;

            if (image.color.a <= 0)
                checkbool = true;



            yield return null;
            Debug.Log("������� �� " + color.a);
        }                                       //�ڷ�ƾ ����
    }
}
