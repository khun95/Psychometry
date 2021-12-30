using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : BaseManager<GameManager>
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject menu;
    private Stack<GameObject> menuStack;
    public static GameObject option;
    public static bool isOpen;
    bool isPause;

    private void Start()
    {
        MouseLock();
        menuStack = new Stack<GameObject>();
    }

    void Update()
    {
        if (canvas == null)
        {
            canvas = GameObject.FindGameObjectWithTag("Canvas");
            menu = canvas.transform.GetChild(1).gameObject;
            option = canvas.transform.GetChild(2).gameObject;
        }
            
        Menu();
    }

    private void Menu()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isOpen = !isOpen;
            if (isOpen)
            {
                MouseOn();
                menu.SetActive(true);
                menuStack.Push(menu);
            }
            else
            {
                MouseLock();
                menu.SetActive(false);
                option.SetActive(false);
                menuStack.Clear();
            }
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Back();
        }
        
    }

    private void MouseLock()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void MouseOn()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    private void Pause()
    {
        isPause = !isPause;
        if(isPause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    public void Option()
    {
        menu.SetActive(false);
        option.SetActive(true);
        menuStack.Push(option);
    }
    public void Back()
    {
        if (menuStack.Count > 0)
        {
            menuStack.Pop().SetActive(false);

            
            if (menuStack.Count > 0)
                menuStack.Peek().SetActive(true);


            else if (menuStack.Count <= 0)
            {
                MouseLock();
                isOpen = false;
            }

        }
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void AppQuit()
    {
        Application.Quit();
    }
}
