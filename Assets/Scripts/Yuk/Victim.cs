using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Victim : Ai
{

    private bool isDie;


    protected override void Start()
    {
        base.Start();
        StartCoroutine(patrol);
    }
    
    
    private void Die()
    {
        StopCoroutine(patrol);
        nav.ResetPath();
        
        nav.enabled = false;
        isDie = true;
        isRun = false;
        isWalk = false;
        isIdle = false;
        anim.SetBool("isWalk", isWalk);
        anim.SetBool("isRun", isRun);
        anim.SetBool("Die", isDie);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        if (other.tag == "Slender" && isDie == false)
            Die();
    }
    
}
