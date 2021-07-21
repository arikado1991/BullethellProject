using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerShipStat : ShipStat
{
    public static UnityEvent  onPlayerGetHitEvent;
    public static UnityEvent<int> onPlayerHealthChangeEvent;
    public static UnityEvent <PlayerShipStat> onPlayerDestroyedEvent;




    // Start is called before the first frame update
    protected override void Awake()
    {
        mTag = Tag.Player;

        
        
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        Reset();
    }
  


    protected override void Reset()
    {
        base.Reset();

        onPlayerHealthChangeEvent.Invoke(mHealth);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void GetHit (int pDamage)
    {
        base.GetHit(pDamage);
        onPlayerGetHitEvent.Invoke();
        onPlayerHealthChangeEvent.Invoke(mHealth);
        if (mHealth <= 0)
        {
            onPlayerDestroyedEvent.Invoke(this);
        }
    }

}
