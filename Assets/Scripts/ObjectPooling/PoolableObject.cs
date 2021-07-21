using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PoolableObject : MonoBehaviour
{

    public delegate void OnPoolableObjectDelegate(PoolableObject poolableObject);
    public event OnPoolableObjectDelegate onPoolableObjectDisableEvent;
    public event OnPoolableObjectDelegate onPoolableObjectEnableEvent;


    //public UnityEvent <PoolableObject> onPoolableObjectEnableEvent;
    //public UnityEvent <PoolableObject> onPoolableObjectDisableEvent;

    protected virtual void Awake()
    {
        //onPoolableObjectEnableEvent = new UnityEvent<PoolableObject> ();
        //onPoolableObjectDisableEvent = new UnityEvent <PoolableObject> ();
    }

    virtual protected void OnEnable()
    {
        try
        {
            onPoolableObjectEnableEvent.Invoke(this);
        }
        catch (System.NullReferenceException)
        {

        }
    }

    virtual protected void OnDisable()
    {
        try
        {
            onPoolableObjectDisableEvent(this);
        }
        catch (System.NullReferenceException)
        {

        }
    }

}
