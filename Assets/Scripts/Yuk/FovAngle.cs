using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FovAngle : MonoBehaviour
{
    [SerializeField] private float viewAngle;
    [SerializeField] private float viewDistance;
    [SerializeField] private Ai ai;
    [SerializeField] private LayerMask layerMask;
    Collider[] targets;

    public bool isbool = true;
    public bool isCoroutine = true;
    // Start is called before the first frame update
    void Start()
    {
        ai = GetComponent<Ai>();
    }

    // Update is called once per frame
    void Update()
    {

        View();
        
        //else
        //{
        //    ai.nav.ResetPath();
        //    isbool = true;
        //}
    }
    private Vector3 BoundaryAngle(float angle_)
    {
        angle_ += transform.eulerAngles.y;
        return new Vector3(Mathf.Sin(angle_ * Mathf.Deg2Rad), 0f, Mathf.Cos(angle_ * Mathf.Deg2Rad));
    }
    private void View()
    {
        
        Vector3 leftAngle = BoundaryAngle(-viewAngle * 0.5f);
        Vector3 rightAngle = BoundaryAngle(viewAngle * 0.5f);

        Debug.DrawRay(transform.position, leftAngle, Color.red);
        Debug.DrawRay(transform.position, rightAngle, Color.red);

        targets = Physics.OverlapSphere(transform.position, viewDistance, layerMask);


        if (targets.Length > 0)
        {
            for (int i = 0; i < targets.Length; i++)
            {
                Transform target = targets[i].transform;
                if (target.tag == "Player")
                {
                    Vector3 destination = (target.position - transform.position).normalized;
                    float angle_ = Vector3.Angle(destination, transform.forward);

                    if (angle_ < viewAngle * 0.5f)
                    {
                        RaycastHit hit;

                        if (Physics.Raycast(transform.position + transform.up, destination, out hit, viewDistance))
                        {
                            if (hit.transform.tag == "Player")
                            {
                                isCoroutine = true;
                                StopCoroutine(ai.patrol);
                                Debug.Log("시야각 안");
                                Debug.DrawRay(transform.position + transform.up, destination, Color.blue);
                                ai.Destination(hit.transform.position);
                                ai.Run();
                            }
                        }
                    }
                }
            }
        }
        else
        {
            Debug.Log("나감");
            //ai.Idle();
            if (isCoroutine)
            {
                StartCoroutine(ai.patrol);  
                //ai.Walk();
                isCoroutine = false;
            }
        }
        
    }
}
