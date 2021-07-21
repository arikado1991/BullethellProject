using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ShipStat : PoolableObject
{

    protected int mHealth;
    [SerializeField] 
    protected int mMaxHealth;
    [SerializeField]
    protected Tag mTag;


    protected override void OnEnable()
    {
        Reset();
    }
    

    protected virtual void Reset()
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
