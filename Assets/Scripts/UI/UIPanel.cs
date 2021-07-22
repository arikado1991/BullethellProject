using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIPanelController : MonoBehaviour
{
    
    // Start is called before the first frame update
    public void Back()
    {
        UIStackController.onUIPanelBackButtonEvent.Invoke();
    }
}

[System.Serializable]
struct ButtonPanelPair
{
    public UIPanelController uiPanelController;
    public Button button;
}