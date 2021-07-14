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
        EnemySpawner.onEnemySpawnEvent = new UnityEvent<ShipStat>();
        EnemySpawner.onEnemyFledEvent = new UnityEvent<ShipStat>();

        PlayerShipStat.onPlayerDestroyedEvent = new UnityEvent <PlayerShipStat>();
        PlayerShipStat.onPlayerGetHitEvent = new UnityEvent ();
        PlayerShipStat.onPlayerHealthChangeEvent = new UnityEvent <int> ();
        PlayerShipStat.onPlayerScoreChangeEvent = new UnityEvent <int> ();

        scene.SetActive(true);
    }
}
