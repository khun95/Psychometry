using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseSound : MonoBehaviour
{
    
    private void OnEnable()
    {
        SoundManager.instance.ChaseClipPlay(3);
    }
}
