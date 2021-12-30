using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundManager : BaseManager<SoundManager>
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] chaceClips;
    [SerializeField] private AudioClip[] sfx;

    private bool isLoad = false;

    public bool IsLoad
    {
        get { return isLoad; }
        set
        {
            isLoad = value;
            if (!isLoad)
            {
                audioSource.clip = null;
                audioSource.Stop();
                isLoad = true;

            }
        }
    }


    private new void Awake()
    {
        base.Awake();

    }

    void Start()
    { 
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //if (SceneManager.GetActiveScene().isLoaded)
        ClearClip();

        //if (Input.GetKeyDown(KeyCode.T))
        //    SceneManager.LoadScene(1);
        //if (Input.GetKeyDown(KeyCode.E))
        //    ChaseClipPlay(0);
        //audioSource.volume = GameManager.option.transform.GetChild(0).GetComponent<Slider>().value;
    }
    public void ClearClip()
    {
        if (!isLoad)
        {
            audioSource.clip = null;
            audioSource.Stop();
            isLoad = true;

        }
    }
    public void ChaseClipPlay(int index)
    {
        audioSource.clip = null;
        audioSource.clip = chaceClips[index];
        audioSource.Play();
    }
    public void SfxClipPlay(int index)
    {
        audioSource.clip = null;
        audioSource.clip = sfx[index];
        audioSource.Play();
    }
}
