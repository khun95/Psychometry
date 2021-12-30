using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameTextManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static TextMeshProUGUI gameText;
    public static TextMeshProUGUI skillText;
    public TextMeshProUGUI temp;
    public TextMeshProUGUI temp2;

    public static bool isFade = false;
    void Start()
    {
        isFade = false;
        gameText = temp;
        skillText = temp2;
        gameText.text = "";
        skillText.text = "";
    }
    public static void TextOnCanvas(bool isbool, string message)
    {
        if (isbool)
        {
            gameText.text = message;
        }
        else
        {
            gameText.text = "";
        }
    }

    public  static void SkillTextOnCanvas(bool isbool)
    {
        if (isbool)
        {
            skillText.text = "Use Psychometry?";
        }
        else
        {
            skillText.text = "";
        }
    }

    public static void ClearCanvas()
    {
        isFade = true;
        gameText.text = "";
        skillText.text = "";
    }
}
