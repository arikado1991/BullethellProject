﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EventInitiator : MonoBehaviour
{

    [SerializeField] GameObject scene;
    [SerializeField] Scene currentScene;
    // Start is called before the first frame update
    void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
        DontDestroyOnLoad(this.gameObject);

        EnemyShipStat.onEnemyDestroyedEvent = new UnityEvent<EnemyShipStat>();

        IngameObjectManager.onObjectSpawnRequestAtIndexedSpawningPointEvent = new UnityEvent<PoolableObject, int, Vector3>();
        IngameObjectManager.onObJectSpawnRequestAtPositionEvent = new UnityEvent <PoolableObject, Vector3, Vector3>();

        IngameObjectManager.onEnemyFledEvent = new UnityEvent<ShipStat>();

        EnemyWaveSpawner.onEnemyShipSpawnEvent = new UnityEvent<EnemyShipStat>();
        EnemyWaveSpawner.onEnemyWaveStartEvent = new UnityEvent<int>();

        PlayerShipStat.onPlayerDestroyedEvent = new UnityEvent <PlayerShipStat>();
        PlayerShipStat.onPlayerGetHitEvent = new UnityEvent ();
        PlayerShipStat.onPlayerHealthChangeEvent = new UnityEvent <int> ();
       

        AudioManager.onPlaySoundRequest = new UnityEvent<string> ();

        AudioManager.onClipFinishEvent = new UnityEvent<PoolableAudioSource> ();

        GameEvaluator.onLevelClearEvent = new UnityEvent();
        GameEvaluator.onPlayerScoreChangeEvent = new UnityEvent<int>();
        GameEvaluator.onNewHighscoreEvent = new UnityEvent<int, int>();
        GameEvaluator.onNormalScoreEvent = new UnityEvent<int, int>();

        OptionsScript.onSoundEffectSettingChange = new UnityEvent<bool>();
        OptionsScript.onBackgroundMusicSettingChange = new UnityEvent<bool>();

        scene.SetActive(true);
    }
}
