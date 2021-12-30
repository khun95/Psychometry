using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YukSceneFadeInOut : MonoBehaviour
{
    public static YukSceneFadeInOut instance;
    [SerializeField] GameObject SplashObj;               
    [SerializeField] Image image;                            

    private bool isIn, isOut;
    private bool checkbool = false; 

    void Awake()
    {
        instance = this;
        SplashObj = GameObject.FindGameObjectWithTag("Panel");
        image = SplashObj.GetComponent<Image>();
       
    }
    private void Start()
    {
        StartCoroutine(FadeOut());
    }


    public IEnumerator FadeIn()
    {

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
                Debug.Log(SceneController.sceneCount);
                SceneController.sceneCount++;
                SceneController.instance.SceneMove(SceneController.sceneCount);
            }
                

            yield return null;
            Debug.Log("어두워지는 중 " + color.a);
        }
    }
    public IEnumerator FadeOut()
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
        }
    }

}

