using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerPowerUpProcessor : MonoBehaviour
{
    public static UnityEvent onExtraShooterPowerUpAcquiredEvent;
    public static UnityEvent onHealthCapsuleAcquiredEvent;
    // Start is called before the first frame update
    void OnEnable()
    {
        PowerUp.onPowerUpAcquireEvent.AddListener(OnPowerUpAcquireEventHandler);
    }

    // Update is called once per frame
    void OnPowerUpAcquireEventHandler (PowerUpType type, object content)
    {
        switch (type)
        {
            case PowerUpType.ExtraShooter:
                onExtraShooterPowerUpAcquiredEvent.Invoke();
                break;
            case PowerUpType.Health:
                onHealthCapsuleAcquiredEvent.Invoke();
                break;
            default:
                break;
        }
    }
}
