using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UseSkillController : MonoBehaviour
{
    public static TextMeshProUGUI gameText;
    public TextMeshProUGUI temp;
    // Start is called before the first frame update
    void Start()
    {
        gameText = temp;
        gameText.text = "";
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
