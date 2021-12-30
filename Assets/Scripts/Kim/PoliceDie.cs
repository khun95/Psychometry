using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class PoliceDie : MonoBehaviour
{
    [SerializeField] int hp = 10;
    Animator ani;
    private void Start()
    {
        ani = GetComponent<Animator>();
    }
    private void Update()
    {
        
        if(EndAnim("Dying"))
        {
            SceneManager.LoadScene(7);
        }
    }
    protected bool EndAnim(string animName)
    {
        return ani.GetCurrentAnimatorStateInfo(0).IsName(animName) &&
               ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hammer")
        {
            if(hp > 0)
            {
                
                hp--;
                // Player Hit Sound
            }
            if (hp <= 0)
            {
                GetComponent<NavMeshAgent>().enabled = false;
                ani.SetTrigger("Die");
                ani.SetBool("Run", false);

            }
        }
        if (other.tag == "Hand")
        {
            if(hp >0)
            {
                GetComponent<Victim>().enabled = true;
                ani.SetBool("Run", true);
                SoundManager.instance.ChaseClipPlay(4);
            }

        }
    }
}
