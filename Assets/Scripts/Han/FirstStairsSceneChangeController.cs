using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstStairsSceneChangeController : MonoBehaviour
{
    [SerializeField] Canvas fadeoutPanel;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            fadeoutPanel.transform.GetChild(0).gameObject.SetActive(true);
            StartCoroutine(YukSceneFadeInOut.instance.FadeIn());
            Debug.Log(SceneController.instance);
           
        }
    }
}
