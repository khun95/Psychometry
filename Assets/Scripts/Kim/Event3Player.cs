using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Event3Player : MonoBehaviour
{
    int hp = 10;
    private void Update()
    {
        if(hp <= 0)
        {
            SceneManager.LoadScene(6);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Hammer")
        {
            hp--;
        }
    }
}
