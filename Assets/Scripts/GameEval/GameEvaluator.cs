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
    int mEnemyFledCount;
    int mEnemyDestroyedCount;

    public static UnityEvent onLevelClearEvent;
    public static UnityEvent<int> onPlayerScoreChangeEvent;

    public static UnityEvent<int, int> onNewHighscoreEvent;
    public static UnityEvent<int, int> onNormalScoreEvent;


    // Start is called before the first frame update
    void OnEnable()
    {
        EnemyShipStat.onEnemyDestroyedEvent.AddListener(OnEnemyDestroyedEventHandler);
        IngameObjectManager.onEnemyFledEvent.AddListener(OnEnemyFledEventHandler);
        EnemyWaveSpawner.onEnemyShipSpawnEvent.AddListener(OnEnemyShipSpawnEventHandler);

        PlayerShipStat.onPlayerDestroyedEvent.AddListener(OnPlayerDestroyedEventHandler);
        EnemyWaveSpawner.onEnemyWaveStartEvent.AddListener(OnWaveStartEventHandler);

        mScore = 0;
        mTotalEnemyCount = mRemainingEnemyCount = mEnemyDestroyedCount = mEnemyFledCount = 0;

    }

    private void OnDisable()
    {
        EnemyShipStat.onEnemyDestroyedEvent.RemoveListener(OnEnemyDestroyedEventHandler);
        IngameObjectManager.onEnemyFledEvent.RemoveListener(OnEnemyFledEventHandler);
        EnemyWaveSpawner.onEnemyShipSpawnEvent.RemoveListener(OnEnemyShipSpawnEventHandler);

        PlayerShipStat.onPlayerDestroyedEvent.RemoveListener(OnPlayerDestroyedEventHandler);
        EnemyWaveSpawner.onEnemyWaveStartEvent.RemoveListener(OnWaveStartEventHandler);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnEnemyDestroyedEventHandler(EnemyShipStat pEnemy)
    {
        mRemainingEnemyCount--;
        mEnemyDestroyedCount++;
        mScore += pEnemy.GetKillScore();
        onPlayerScoreChangeEvent.Invoke(mScore);
        CheckWaveEnded();

    }

    void OnEnemyFledEventHandler(ShipStat enemy)
    {
        mEnemyFledCount++;
        mRemainingEnemyCount--;
        CheckWaveEnded();
    }

    void OnPlayerDestroyedEventHandler(PlayerShipStat player)
    {

    }

    void OnEnemyShipSpawnEventHandler(EnemyShipStat enemy)
    {
        mRemainingEnemyCount++;
    }

    bool CheckWaveEnded()
    {
        if (mTotalEnemyCount > mEnemyFledCount + mEnemyDestroyedCount)
        {
            return false;
        }
        EndWave();
        return true;
    }

    void EndWave()
    {

        onLevelClearEvent.Invoke();
        OnDisable();
        int prevHighscore = PlayerPrefs.GetInt("Highscore", -1);
        if (prevHighscore < mScore)
        {
            PlayerPrefs.SetInt("Highscore", mScore);
            onNewHighscoreEvent.Invoke(mScore, prevHighscore);

        }
        else
        {
            onNormalScoreEvent.Invoke(mScore, prevHighscore);
#if DEBUG

            PlayerPrefs.DeleteKey("Highscore");
#endif
        }
    }

    void OnWaveStartEventHandler(int waveEnemyCount)
    {
        Debug.Log("Wave enemy count = " + waveEnemyCount);
        mTotalEnemyCount = waveEnemyCount;
    }
}
