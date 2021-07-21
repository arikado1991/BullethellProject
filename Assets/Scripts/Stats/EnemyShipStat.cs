using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyShipStat : ShipStat
{
    public static UnityEvent <EnemyShipStat> onEnemyDestroyedEvent;
    [SerializeField] protected int mKillScore;
    // Start is called before the first frame update
    protected override void Awake()
    {
        mTag = Tag.Enemy;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void GetHit (int pDamage)
    {
        base.GetHit(pDamage);
        if (mHealth <= 0)
        {
            onEnemyDestroyedEvent.Invoke(this);
        }
    }

    public int GetKillScore ()
    {
        return mKillScore;
    }
}
