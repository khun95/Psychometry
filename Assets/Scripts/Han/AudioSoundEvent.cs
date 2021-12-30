using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSoundEvent : MonoBehaviour
{
    // Start is called before the first frame update
    private static AudioSource[] audioSource;
    void Start()
    {
        audioSource = GameObject.Find("SoundEvent").GetComponents<AudioSource>();
    }

    public static void DoorOpenClose(bool isbool)
    {
        if (isbool)
        {
            audioSource[0].Play();
        }
        else
        {
            audioSource[1].Play();
        }
    }
    public static void DrawOpenClose(bool isbool)
    {
        if (isbool)
        {
            audioSource[2].Play();
        }
        else
        {
            audioSource[3].Play();
        }
    }

    public static void KeyPadUnlock()
    {
        audioSource[4].Play();
    }
    public static void KeyPadUnlockFailure()
    {
        audioSource[5].Play();
    }
    public static void DoorUnlock()
    {
        audioSource[6].Play();
    }
    public static void PlaySiren()
    {
        audioSource[7].Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
