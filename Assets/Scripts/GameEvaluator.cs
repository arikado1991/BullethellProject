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
    public static UnityEvent<int> onPlayerScoreChangeEvent;

    public static UnityEvent<int, int> onNewHighscoreEvent;
    public static UnityEvent<int, int> onNormalScoreEvent;


    // Start is called before the first frame update
    void OnEnable()
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
        mEenemyFledCount++;
        mRemainingEnemyCount--;
        CheckWaveEnded();
    }

    void OnPlayerDestroyedEventHandler(PlayerShipStat player)
    {

    }

    void OnEnemyShipSpawnEventHandler(EnemyShipStat enemy)
    {
        mTotalEnemyCount++;
        mRemainingEnemyCount++;
    }

    bool CheckWaveEnded()
    {
        if (mTotalEnemyCount == 6 &&  mRemainingEnemyCount == 0)
        {
            EndWave();
            return true;
        }
        return false;
    }

    void EndWave()
    {
        onLevelClearEvent.Invoke();
        int prevHighscore = PlayerPrefs.GetInt("Highscore", -1);
        if (prevHighscore < mScore)
        {
            PlayerPrefs.SetInt("Highscore", mScore);
            onNewHighscoreEvent.Invoke(mScore, prevHighscore);

        }
        else
        {
            onNormalScoreEvent.Invoke(mScore, prevHighscore);
            PlayerPrefs.DeleteKey("Highscore");
        }
    }
}
