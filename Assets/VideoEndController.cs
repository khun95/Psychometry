using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;
public class VideoEndController : MonoBehaviour
{
    // Start is called before the first frame update
    VideoPlayer videoPlayer;
    public TextMeshProUGUI gameText;
    public GameObject panel;
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.Play();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (videoPlayer.isPaused)
        {

            //videoPlayer.gameObject.SetActive(false);
            //gameText.gameObject.SetActive(true);
            panel.SetActive(true);
            if (OVRInput.GetDown(OVRInput.Button.Any))
            {
                GameSceneManager.sceneNum = 0;
                SceneManager.LoadScene(0);
            }
        }
    }
}
