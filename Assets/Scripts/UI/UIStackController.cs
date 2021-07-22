using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIStackController : MonoBehaviour
{
    Stack<UIPanelController> mUIStack;

    public static UnityEvent onUIPanelBackButtonEvent;
    public static UnityEvent <UIPanelController> onLoadUIPanelRequestEvent;

    // Start is called before the first frame update

    private void Awake()
    {
        mUIStack = new Stack<UIPanelController>();
    }
    void OnEnable()
    {
        onUIPanelBackButtonEvent.AddListener(Back);
        onLoadUIPanelRequestEvent.AddListener(PushUIPanel);
    }

    void OnDisable()
    {
        onUIPanelBackButtonEvent.RemoveListener(Back);
        onLoadUIPanelRequestEvent.RemoveListener(PushUIPanel);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void Back()
    {
        UIPanelController top = mUIStack.Pop();
        try
        {
            top.gameObject.SetActive(false);
        }
        catch (System.NullReferenceException )
        {
            Debug.Log("Stack is empty.");
            return;
        }

        if (mUIStack.Peek() == null)
        {
            PushUIPanel(top);
        }
        
        mUIStack.Peek().gameObject.SetActive(true);
    }

    void PushUIPanel(UIPanelController panel)
    {
        try
        {
            mUIStack.Peek().gameObject.SetActive(false);
            
        }
        catch (System.InvalidOperationException)
        {
            Debug.Log("Stack is currently empty.");
        }
        mUIStack.Push(panel);
        panel.gameObject.SetActive(true);
    }
}
