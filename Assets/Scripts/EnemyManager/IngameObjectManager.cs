using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class IngameObjectManager : MonoBehaviour
{
    static public UnityEvent <ShipStat> onEnemyFledEvent;
    static public UnityEvent<PoolableObject, int, Vector3> onObjectSpawnRequestAtIndexedSpawningPointEvent;
    static public UnityEvent<PoolableObject, Vector3, Vector3> onObJectSpawnRequestAtPositionEvent;
   
    // Start is called before the first frame update
    // GameObject[] spawningList;
    static IngameObjectManager mInstance;
    public static IngameObjectManager Instance()
    {
        return mInstance;
    }


    Dictionary<string, ObjectPool> mObjectPoolDictionary;

    void Awake()
    {
        if (mInstance == null)
        {
            mInstance = this;
        }
        else
        {
            GameObject.Destroy(this);
        }

        mObjectPoolDictionary = new Dictionary<string, ObjectPool>();
    }

    void OnEnable()
    {
        onEnemyFledEvent.AddListener(OnEnemyFledEventHandler);
        EnemyShipStat.onEnemyDestroyedEvent.AddListener (OnEnemyFledEventHandler);
        


    }

    void OnDisable() 
    {
        onEnemyFledEvent.RemoveListener(OnEnemyFledEventHandler);
        EnemyShipStat.onEnemyDestroyedEvent.RemoveListener (OnEnemyFledEventHandler);
    }

    void OnEnemyFledEventHandler (ShipStat enemy)
    {
        enemy.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            /*
            if (cooldown <= 0)
            {
                int spawningPointIndex = 0;
                Vector3 spawnPosition = mSpawningPointTransforms[spawningPointIndex].position;

                ShipStat newEnemySample = mWaveDescription.mEnemySpawningInstruction[currentEnemyIndex].mEnemyController;

                PoolableObject newEnemy = SpawnObject(spawnPosition, newEnemySample, Vector3.down);
                try
                {
                    onEnemyShipSpawnEvent.Invoke(newEnemy.GetComponent<EnemyShipStat>());
                } 
                catch (System.NullReferenceException)
                {
                    Debug.LogError("Missing EnemyShipStat component in enemy prefab.");
                }

                cooldown = mWaveDescription.mEnemySpawningInstruction[currentEnemyIndex].mDelay;
                currentEnemyIndex += 1;
            }
            cooldown -= Time.deltaTime;*/
        }
        catch (IndexOutOfRangeException)
        {
            Debug.LogError("Wave is clear.\n");
            return;
        }
    }

    public PoolableObject SpawnObject (Vector3 spawnPosition, PoolableObject objectSample, Vector3 facingDirection)
    {
        PoolableObject newObjectInstance;
 
        ObjectPool pool;
        try
        {
            pool = mObjectPoolDictionary[objectSample.name];
        }
        catch (KeyNotFoundException)
        {
            pool = new ObjectPool();
            pool.Init(objectSample, 5);

            mObjectPoolDictionary[objectSample.name] = pool;


        }
        newObjectInstance = pool.GetObject();

        newObjectInstance.transform.position = spawnPosition;

        newObjectInstance.transform.up = facingDirection;

        return newObjectInstance;
    }
}
