using System.Collections;
using UnityEngine;

public class SixthSense : MonoBehaviour
{

    [System.Serializable]
    public struct SixthSenseIamge
    {
        public GameObject playerImage;
        public float delay;
    }
    

    public GameObject[] playerImages;
    public SixthSenseIamge[] sixthSenseIamges;
    public int test;

    private void Start()
    {
        StartCoroutine(ImageActive());
    }
    private void Update()
    {
        if (playerImages == null) Destroy(gameObject);
    }
    IEnumerator ImageActive()
    {

        #region 구조체 적용
        /*
        for (int i = 0; i < sixthSenseIamges.Length; i++)
        {
            yield return new WaitForSeconds(sixthSenseIamges[i].delay);
            sixthSenseIamges[i].playerImage.SetActive(true);
        }
        */
        #endregion

        for (int i = 0; i < playerImages.Length; i++)
        {
            if (i == 2)
            {
                yield return new WaitForSeconds(3);
            }
            playerImages[i].SetActive(true);
            Debug.Log(i);
            yield return new WaitForSeconds(2);
        }
        playerImages = null;
    }
}
