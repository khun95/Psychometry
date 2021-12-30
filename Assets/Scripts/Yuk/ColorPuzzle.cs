using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorPuzzle : MonoBehaviour
{
    [SerializeField] private GameObject openDoor;
    [SerializeField] private ColorType colorType;
    [SerializeField] private ColorPuzzle[] puzzles;

    public static string answer;
    public static bool isSuccess;

    public bool isClick;

    
    private enum ColorType
    {
        Red = 1,
        Blue,
        Green,
        Yellow
    }
    private void Start()
    {
        puzzles = transform.parent.GetComponentsInChildren<ColorPuzzle>();
    }
    private void ResetPuzzle()
    {
        for (int i = 0; i < puzzles.Length; i++)
            puzzles[i].isClick = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            
            if (isClick == false)
            {
                answer += (int)colorType;
                SoundManager.instance.SfxClipPlay(0);
                // 클릭 사운드
                if (answer.Length == 4)
                {
                    
                    if (answer == "1234")
                    {
                        // 성공 사운드
                        SoundManager.instance.SfxClipPlay(1);
                        Debug.Log("Success");
                        isSuccess = true;
                        openDoor.GetComponent<DoorObjectControllers>().enabled = true;
                    }

                    else
                    {
                        // 실패 사운드
                        SoundManager.instance.SfxClipPlay(2);
                        Debug.Log("실패");
                        ResetPuzzle();

                    }
                    Debug.Log("Pass : " + answer);
                    answer = "";
                    return;
                }
                Debug.Log("Pass : " + answer);
            }
            isClick = true;
        }
    }
}
