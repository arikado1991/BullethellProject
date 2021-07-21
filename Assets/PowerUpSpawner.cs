using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{

    [SerializeField] PowerUpRngTable mPowerUpRngTable;
    // Start is called before the first frame update
    private void OnEnable()
    {
        EnemyWaveSpawner.onEnemyShipSpawnEvent.AddListener(RollPowerUp);
    }

    private void RollPowerUp (EnemyShipStat shipStat)
    {
        int roll = Random.Range(0, 99);
        int currentItemRate;
        PowerUp currentPowerUp;

        for (int i = 0; i < mPowerUpRngTable.mTable.Length; i++)
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
}
