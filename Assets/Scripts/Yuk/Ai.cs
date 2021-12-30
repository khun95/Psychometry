using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Ai : MonoBehaviour
{
    [SerializeField] public NavMeshAgent nav;
    [SerializeField] protected Animator anim;
    [SerializeField] public List<Transform> targetsTf;
    public IEnumerator patrol;
    protected bool isRun;
    protected bool isWalk;
    protected bool isIdle;
    protected int maxCount = 0;


    protected virtual void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        patrol = Patrol();
        
    }
    private void Update()
    {
        if(EndAnim("Attack") && SceneManager.GetActiveScene().buildIndex != 6)
        {
            GameSceneManager.LoadScene();
        }
    }
    private void OnEnable()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        patrol = Patrol();
    }


    public void Destination(Vector3 targetPos)
    {
        nav.SetDestination(targetPos);
    }
    public void Run()
    {
        
        isRun = true;
        isWalk = false;
        isIdle = false;
        anim.SetBool("isRun", isRun);
        anim.SetBool("isIdle", isIdle);
        anim.SetBool("isWalk", isWalk);
        nav.speed = 3f;
    }
    public void Walk()
    {
        isWalk = true;
        isRun = false;
        isIdle = false;
        anim.SetBool("isRun", isRun);
        anim.SetBool("isWalk", isWalk);
        nav.speed = 2f;
    }
    public void Idle()
    {
        isIdle = true;
        isWalk = false;
        isRun = false;
        
        anim.SetBool("isIdle", isIdle);
        anim.SetBool("isWalk", isWalk);
        anim.SetBool("isRun", isRun);
    }
    protected IEnumerator Patrol()
    {
        Debug.Log("Patrol");
        while(true)
        {
            Destination(targetsTf[maxCount].position);
            Walk();
           
            if (Vector3.Distance(transform.position,targetsTf[maxCount].position) < 1)
            {
               // Debug.Log(targetsTf.Count + " " + count);
                if (maxCount == targetsTf.Count - 1)
                    maxCount = 0;
                else
                    maxCount++;

                Destination(targetsTf[maxCount].position);

            }
            
            yield return null;
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        GetComponent<FovAngle>().isbool = false;
    //        Debug.Log("atk");
    //        anim.SetTrigger("Attack");
    //    }
    //}
    protected bool EndAnim(string animName)
    {
        return anim.GetCurrentAnimatorStateInfo(0).IsName(animName) &&
               anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (SceneManager.GetActiveScene().buildIndex != 6)
                SoundManager.instance.ChaseClipPlay(1);
            else
            {
                // EventScene3 Hit Sound
            }
            GetComponent<FovAngle>().isbool = false;
            Debug.Log("atk");
            anim.SetTrigger("Attack");
            
        }

        if (other.gameObject.tag == "Hand")
        {
            Debug.Log("HandTrigger");
            anim.SetTrigger("Attack");
            //if ()
            //{
            //    Debug.Log("���� Attack");
            //    SceneController.sceneCount++;
            //    SceneController.instance.SceneMove(SceneController.sceneCount);
            //}
        }
        
    }
}
