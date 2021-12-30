using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : BaseManager<SceneController>
{
    
    public static int sceneCount = 0;

    public void SceneMove(int count)
    {
        SceneManager.LoadScene(count);
    }
}
