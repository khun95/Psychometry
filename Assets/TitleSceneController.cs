using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TitleSceneController : MonoBehaviour
{
    public Image image1;
    public Image image2;
    public Image image3;
    bool isImage2 = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (image2.IsActive())
        {
            isImage2 = true;
        }
        if (OVRInput.GetDown(OVRInput.Button.Any))
        {
            image1.gameObject.SetActive(false);
            image2.gameObject.SetActive(true);
        }
        if (isImage2)
        {
            if (OVRInput.GetDown(OVRInput.Button.Any))
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
