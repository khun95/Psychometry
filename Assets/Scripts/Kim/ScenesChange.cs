using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesChange : MonoBehaviour
{
    public int sceneNumber;
    public string tagName;
    bool isFlash = false;
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.CompareTag("Police"))
    //    {
    //        SceneManager.LoadScene(sceneNumber);
    //        Debug.Log(collision.collider.name);
    //    }
            
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            GameTextManager.SkillTextOnCanvas(true);
            isFlash = true;
        }
        if (other.tag == tagName)
        {
            SceneManager.LoadScene(9);
            Debug.Log(other.name);
        }
    }

    private void Update()
    {
        if (isFlash)
        {
            if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            {
                SceneManager.LoadScene(7);
                GameTextManager.SkillTextOnCanvas(false);
            }
        }
    }
}
