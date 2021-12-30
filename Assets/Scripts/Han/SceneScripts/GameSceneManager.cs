using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameSceneManager : MonoBehaviour
{
    public static int sceneNum = 2;
    public static void LoadScene()
    {
        SceneManager.LoadScene(GameSceneManager.sceneNum);
        GameSceneManager.sceneNum++;
    }
    public static void LoadEventScene1(int sceneNum)
    {
        SceneManager.LoadScene(1);
    }
    public static void LoadScene2()
    {
        SceneManager.LoadScene(2);
    }
    public static void LoadEventScene2()
    {
        SceneManager.LoadScene(3);
    }
    public static void LoadScene3()
    {
        SceneManager.LoadScene(4);
    }
}
