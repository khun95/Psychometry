using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneFadeInOut : MonoBehaviour
{
    public static GameObject SplashObj;               //판넬오브젝트
    public static Image image;                            //판넬 이미지
    public static bool checkbool = false;     //투명도 조절 논리형 변수

    IEnumerator stop;
    void Awake()
    {
        SplashObj = GameObject.FindGameObjectWithTag("Panel");                         //스크립트 참조된 오브젝트
        image = SplashObj.GetComponent<Image>();    //판넬오브젝트에 이미지 참조
        stop = FadeOut();
    }


    void Update()
    {
        StartCoroutine(stop);                        //코루틴    //판넬 투명도 조절
        if (checkbool)                                            //만약 checkbool 이 참이면
        {
            StopCoroutine(stop);
            //SplashObj.SetActive(false);                       //판넬 파괴, 삭제
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
            Debug.Log("밝아지는 중 " + color.a);
        }                                       //코루틴 종료
    }
}
