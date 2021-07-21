using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public  class ShooterController : MonoBehaviour
{
    protected Tag mTag; 
    protected UnityEvent mOnShootEvent;

    Shooter[] mShooters = null;
    // Start is called before the first frame update
    virtual protected void Awake()
    {
        mOnShootEvent = new UnityEvent();
    }

    virtual protected void OnEnable() 
    {
        ReadyAllShooters();
    }

    virtual protected void OnDisable() 
    {
        ClearAllShooter();
    }

    virtual protected void ReadyAllShooters ()
    {
        ClearAllShooter();
        mShooters = transform.GetComponentsInChildren<Shooter> ();
     
        try 
        {
            foreach (Shooter s in mShooters)
            {
                s.SetTag (mTag);
                mOnShootEvent.AddListener (s.Shoot);
            }
        }
        catch (NullReferenceException  e) 
        {
            Debug.Log (String.Format("No shooter components found in the children of %s.\n", gameObject.name));
        }
    }

    virtual protected void ClearAllShooter () 
    {
        try 
        {
            foreach (Shooter s in mShooters)
            {
                mOnShootEvent.RemoveListener (s.Shoot);
            }
        }
        catch (NullReferenceException  e) 
        {
            Debug.Log (String.Format("No shooter components found in the children of {0}.\n" , gameObject.name));
        }
    }

    protected void SetTag (Tag pTag)
    {
        mTag = pTag;
    }
}
