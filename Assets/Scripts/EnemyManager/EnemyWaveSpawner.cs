using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyWaveSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    private float cooldown;
    [SerializeField] WaveDescription mWaveDescription;
    [SerializeField] Transform[] mSpawningPointTransforms;
    private int currentEnemyIndex;

    public static UnityEvent<int> onEnemyWaveStartEvent;
    public static  UnityEvent<EnemyShipStat> onEnemyShipSpawnEvent;

    private void OnEnable()
    {
       
        onEnemyWaveStartEvent.Invoke(mWaveDescription.mEnemySpawningInstruction.GetLength(0))   ;
    }

    void Update()
    {
        try
        {

            if (cooldown <= 0)
            {
                int spawningPointIndex = 0;
                Vector3 spawnPosition = mSpawningPointTransforms[spawningPointIndex].position;

                ShipStat newEnemySample = mWaveDescription.mEnemySpawningInstruction[currentEnemyIndex].mEnemyController;

                PoolableObject newEnemy =  IngameObjectManager.Instance().SpawnObject(spawnPosition, newEnemySample, Vector3.down);
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
            cooldown -= Time.deltaTime;
        }
        catch (System.IndexOutOfRangeException)
        {
            Debug.LogError("Wave is clear.\n");
            return;
        }
    }

}
