using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class EnemySpawner : MonoBehaviour
{
    static public UnityEvent <ShipStat> onEnemyFledEvent;
    static public UnityEvent<PoolableObject, int, Vector3> onObjectSpawnRequestAtIndexedSpawningPoint;
    static public UnityEvent<PoolableObject, Vector3, Vector3> onObJectSpawnRequestAtPosition;

    // Start is called before the first frame update
    // GameObject[] spawningList;
    static EnemySpawner mInstance;
    public static EnemySpawner Instance()
    {
        return mInstance;
    }

    [SerializeField]
    WaveDescription mWaveDescription;

    [SerializeField]
    Transform[] mSpawningPointTransforms;
    float cooldown;
    int currentEnemyIndex;

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
        cooldown = 3;
        currentEnemyIndex = 0;

 

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

            if (cooldown <= 0)
            {
                int spawningPointIndex = 0;
                Vector3 spawnPosition = mSpawningPointTransforms[spawningPointIndex].position;

                ShipStat newEnemySample = mWaveDescription.mEnemySpawningInstruction[currentEnemyIndex].mEnemyController;

                SpawnObject(spawnPosition, newEnemySample, Vector3.down);

                cooldown = mWaveDescription.mEnemySpawningInstruction[currentEnemyIndex].mDelay;
                currentEnemyIndex += 1;
            }
            cooldown -= Time.deltaTime;
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
