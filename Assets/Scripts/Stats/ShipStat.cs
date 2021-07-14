using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ShipStat : MonoBehaviour
{

    protected int mHealth;
    [SerializeField] 
    protected int mMaxHealth;
    [SerializeField]
    protected Tag mTag;


    protected virtual void OnEnable()
    {
        Reset();
    }
    

    virtual protected void Reset()
    {
        mHealth = mMaxHealth;
    }

    protected virtual void GetHit (int pDamage)
    {
        mHealth -= pDamage;
        
    }

    public void SetTag (Tag pTag)
    {
        mTag = pTag;
    }

    public Tag GetTag ()
    {
        return mTag;
    }
}
