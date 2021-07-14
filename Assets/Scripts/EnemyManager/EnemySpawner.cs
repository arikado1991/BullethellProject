using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class EnemySpawner : MonoBehaviour
{
    static public UnityEvent <ShipStat> onEnemySpawnEvent;
    static public UnityEvent <ShipStat> onEnemyFledEvent;

    // Start is called before the first frame update
   // GameObject[] spawningList;

    [SerializeField]
    WaveDescription mWaveDescription;
    float cooldown;
    int currentEnemyIndex;
    
    void Awake()
    {
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
        GameObject.Destroy (enemy.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        try
        {

            if (cooldown <= 0)
            {
                Vector3 spawnPosition = new Vector3 ( UnityEngine.Random.Range ( -7, 7 ) , 3.5f, 0);

                ShipStat newEnemySample = mWaveDescription.mEnemySpawningInstruction[currentEnemyIndex].mEnemyController;

                ShipStat newEnemyInstance = GameObject.Instantiate (newEnemySample, spawnPosition, Quaternion.identity );
                newEnemyInstance.transform.up = Vector3.down;
                
                onEnemySpawnEvent.Invoke(newEnemyInstance);

                cooldown = mWaveDescription.mEnemySpawningInstruction[currentEnemyIndex].mDelay;
                currentEnemyIndex += 1;
            }
            cooldown -= Time.deltaTime;
        }
        catch (IndexOutOfRangeException e)
        {
            Debug.LogError("Wave is clear.\n");
            return;
        }
    }
}
