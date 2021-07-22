using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EventInitiator : MonoBehaviour
{

    [SerializeField] GameObject scene;
    // Start is called before the first frame update
    void Awake()
    {
        
        if ( EnemyShipStat.onEnemyDestroyedEvent == null )
        {

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
            AudioManager.onPlayBGMRequest = new UnityEvent<string> ();
            AudioManager.onClipFinishEvent = new UnityEvent<PoolableAudioSource> ();
            AudioManager.onSoundSettingChangeEvent = new UnityEvent<bool>();
            AudioManager.onBGMSettingChangeEvent = new UnityEvent<bool>();


            GameEvaluator.onLevelClearEvent = new UnityEvent();
            GameEvaluator.onPlayerScoreChangeEvent = new UnityEvent<int>();
            GameEvaluator.onNewHighscoreEvent = new UnityEvent<int, int>();
            GameEvaluator.onNormalScoreEvent = new UnityEvent<int, int>();


            PowerUp.onPowerUpAcquireEvent = new UnityEvent<PowerUpType, Object>();
            PlayerPowerUpProcessor.onExtraShooterPowerUpAcquiredEvent = new UnityEvent();
            PlayerPowerUpProcessor.onHealthCapsuleAcquiredEvent = new UnityEvent();

            UIStackController.onLoadUIPanelRequestEvent = new UnityEvent<UIPanelController>();
            UIStackController.onUIPanelBackButtonEvent = new UnityEvent();
        
        }
    //   OptionsScript.onSoundEffectSettingChange = new UnityEvent<bool>();
    //  OptionsScript.onBackgroundMusicSettingChange = new UnityEvent<bool>();

        try
        {
            scene.SetActive(true);
        }
        catch (UnassignedReferenceException)
        {

        }
        GameObject.Destroy(gameObject);
    }
}
