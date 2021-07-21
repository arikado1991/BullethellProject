using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuBehaciour : MonoBehaviour
{
    public Button start, help, option, returnButton, quit;
    void Start()
    {
        
    }
    void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void OnPressedStart()
    { 
        SceneManager.LoadScene("Level1");
    }
    public void OnPressedHelp()
    {
        SceneManager.LoadScene("HelpScene");
    }
    public void OnPressedOptions()
    {
        SceneManager.LoadScene("OptionsScene");
    }
    public void OnPressedReturn()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void OnPressedQuit()
    {
        Application.Quit(1);
    }
}
