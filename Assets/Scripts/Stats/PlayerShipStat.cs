using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerShipStat : ShipStat
{
    public static UnityEvent  onPlayerGetHitEvent;
    public static UnityEvent <int> onPlayerHealthChangeEvent;
    public static UnityEvent <int> onPlayerScoreChangeEvent;
    public static UnityEvent <PlayerShipStat> onPlayerDestroyedEvent;


    int mScore = 0;

    // Start is called before the first frame update
    void Awake()
    {
        mTag = Tag.Player;

        
        
    }

    protected override void OnEnable ()
    {
        base.OnEnable();
        EnemyShipStat.onEnemyDestroyedEvent.AddListener (OnEnemyDestroyedEventHandler);

        Reset();

    }

    protected void OnDisable ()
    {
        EnemyShipStat.onEnemyDestroyedEvent.RemoveListener (OnEnemyDestroyedEventHandler);
    }


    protected override void Reset()
    {
        base.Reset();

        mScore = 0;
        onPlayerHealthChangeEvent.Invoke(mHealth);
        onPlayerScoreChangeEvent.Invoke (mScore);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void GetHit (int damage)
    {
        base.GetHit(damage);
        onPlayerGetHitEvent.Invoke();
        onPlayerHealthChangeEvent.Invoke(mHealth);
        if (mHealth <= 0)
        {
            onPlayerDestroyedEvent.Invoke(this);
        }
    }

    void OnEnemyDestroyedEventHandler(EnemyShipStat pEnemy)
    {
        mScore += pEnemy.GetKillScore();
        onPlayerScoreChangeEvent.Invoke (mScore);
    }
}
