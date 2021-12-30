using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evidence : MonoBehaviour
{
    [SerializeField] private GameObject slender;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject[] disableObj;

    [SerializeField] private float waitTime;
    [SerializeField] private int evidenceNum;
    private bool isFirst = true;
    
    // 플레이어가 증거 발견 시

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Hand")
        {
            if (evidenceNum == 1)
                SoundManager.instance.ChaseClipPlay(2);
            else if (evidenceNum == 2)
                SoundManager.instance.ChaseClipPlay(0);
            
            player = GameObject.FindGameObjectWithTag("Player");
            if (disableObj.Length > 0)
                DisableLight();
            StartCoroutine(Chase());
        }
    }
    
    // 플레이어 추격
    private IEnumerator Chase()
    {
        while (true)
        {
            if (isFirst)
                yield return new WaitForSeconds(waitTime);
            else
            {
                slender.SetActive(true);
                slender.GetComponent<Ai>().Run();
                slender.GetComponent<Ai>().Destination(player.transform.position);
            }

            isFirst = false;
            yield return null;
            
        }
    }

    // 조명 비활성화
    private void DisableLight()
    {

        for (int i = 0; i < disableObj.Length; i++)
        {
            if (disableObj[i].GetComponent<Light>() != null)
                disableObj[i].GetComponent<Light>().enabled = false;
        }
    }
}
