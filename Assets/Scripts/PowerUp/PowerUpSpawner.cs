using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    int mSum;
    [SerializeField] PowerUpRngTable mPowerUpRngTable;
    // Start is called before the first frame update
    private void OnEnable()
    {
        GetSum();
        EnemyWaveSpawner.onEnemyShipSpawnEvent.AddListener(RollPowerUp);
    }

    private void RollPowerUp (EnemyShipStat shipStat)
    {
        int roll = Random.Range(0, mSum);
        int currentItemRate;
        PowerUp currentPowerUp;

        for (int i = 0; i < mPowerUpRngTable.mTable.Length - 1; i++)
        {
            currentItemRate = mPowerUpRngTable.mTable[i].rate;
            currentPowerUp = mPowerUpRngTable.mTable[i].powerUp;
            if (roll < currentItemRate)
            {
                DropOnDestroy newDrop = shipStat.gameObject.AddComponent<DropOnDestroy>();
                newDrop.dropPrefab = currentPowerUp;
                return;
            }
            else
            {
                roll -= currentItemRate;
            }
        }
    }

    void GetSum()
    {
        mSum = 0;
        foreach (PowerUpRng rng in mPowerUpRngTable.mTable)
        {
            mSum += rng.rate;
        }
    }
}
