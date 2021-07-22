using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUIPanelController : UIPanelController
{

    void Start()
    {
        UIStackController.onLoadUIPanelRequestEvent.Invoke(this);
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
    public void OnPressedHelp(UIPanelController controller)
    {
        UIStackController.onLoadUIPanelRequestEvent.Invoke(controller);
    }
    public void OnPressedOptions(UIPanelController optionPanel)
    {
        UIStackController.onLoadUIPanelRequestEvent.Invoke(optionPanel);
    }
    public void OnPressedReturn()
    {
        UIStackController.onUIPanelBackButtonEvent.Invoke();
    }
    public void OnPressedQuit()
    {
        Application.Quit(1);
    }
}
