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

        GameEvaluator.onGameEndEvent.AddListener (OnGameEndEventHandler);
        


    }

    void OnDisable() 
    {
        onEnemyFledEvent.RemoveListener(OnEnemyFledEventHandler);
        EnemyShipStat.onEnemyDestroyedEvent.RemoveListener (OnEnemyFledEventHandler);
        GameEvaluator.onGameEndEvent.RemoveListener(OnGameEndEventHandler);
    }

    void OnEnemyFledEventHandler (ShipStat enemy)
    {
        enemy.gameObject.SetActive(false);
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
            GameObject poolParentGameObject =  new GameObject();
            poolParentGameObject.transform.SetParent(transform);
            poolParentGameObject.name = string.Format ("{0}Pool", objectSample.name);
            pool.SetParentTransform(poolParentGameObject.transform); 

            pool.Init(objectSample, 5);

            mObjectPoolDictionary[objectSample.name] = pool;


        }
        newObjectInstance = pool.GetObject();

        newObjectInstance.transform.position = spawnPosition;

        newObjectInstance.transform.up = facingDirection;

        return newObjectInstance;
    }

    void OnGameEndEventHandler()
    {
        gameObject.SetActive(false);
    }
}
