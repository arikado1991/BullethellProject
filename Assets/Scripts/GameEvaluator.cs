using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvaluator : MonoBehaviour
{
    int mScore;
    int mPlayerHealth;
    int mTotalEnemyCount;
    int mRemainingEnemyCount;
    int mEenemyFledCount;
    int mEnemyDestroyedCount;

    public static UnityEvent onLevelClearEvent;



    // Start is called before the first frame update
    void OnEnable ()
    {
        EnemyShipStat.onEnemyDestroyedEvent.AddListener(OnEnemyDestroyedEventHandler);
        EnemySpawner.onEnemyFledEvent.AddListener(OnEnemyFledEventHandler);
        EnemySpawner.onEnemyShipSpawnEvent.AddListener(OnEnemyShipSpawnEventHandler);

        PlayerShipStat.onPlayerDestroyedEvent.AddListener(OnPlayerDestroyedEventHandler);

        mScore = 0;
        mTotalEnemyCount = mRemainingEnemyCount = mEnemyDestroyedCount = mEenemyFledCount = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnemyDestroyedEventHandler (EnemyShipStat enemy)
    {
        mRemainingEnemyCount--;
        mEnemyDestroyedCount++;

        if (mTotalEnemyCount == 20 &&  mRemainingEnemyCount == 0)
        {
            onLevelClearEvent.Invoke();
        }
    }

    void OnEnemyFledEventHandler (ShipStat enemy)
    {
        mEenemyFledCount++;
        mRemainingEnemyCount--;
    }

    void OnPlayerDestroyedEventHandler (PlayerShipStat player)
    {
       
    }

    void OnEnemyShipSpawnEventHandler (EnemyShipStat enemy)
    {
        mTotalEnemyCount++;
        mRemainingEnemyCount++;
    }


}
