using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventInitiator : MonoBehaviour
{

    [SerializeField] GameObject scene;
    // Start is called before the first frame update
    void Awake()
    {
        EnemyShipStat.onEnemyDestroyedEvent = new UnityEvent<EnemyShipStat>();

        EnemySpawner.onObjectSpawnRequestAtIndexedSpawningPointEvent = new UnityEvent<PoolableObject, int, Vector3>();
        EnemySpawner.onObJectSpawnRequestAtPositionEvent = new UnityEvent <PoolableObject, Vector3, Vector3>();

        EnemySpawner.onEnemyFledEvent = new UnityEvent<ShipStat>();
        EnemySpawner.onEnemyShipSpawnEvent = new UnityEvent<EnemyShipStat>();

        PlayerShipStat.onPlayerDestroyedEvent = new UnityEvent <PlayerShipStat>();
        PlayerShipStat.onPlayerGetHitEvent = new UnityEvent ();
        PlayerShipStat.onPlayerHealthChangeEvent = new UnityEvent <int> ();
       

        AudioManager.onPlaySoundRequest = new UnityEvent<string> ();

        AudioManager.onClipFinishEvent = new UnityEvent<PoolableAudioSource> ();

        GameEvaluator.onLevelClearEvent = new UnityEvent();
        GameEvaluator.onPlayerScoreChangeEvent = new UnityEvent<int>();
        GameEvaluator.onNewHighscoreEvent = new UnityEvent<int, int>();
        GameEvaluator.onNormalScoreEvent = new UnityEvent<int, int>();

        scene.SetActive(true);
    }
}
