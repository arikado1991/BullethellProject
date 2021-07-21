using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum PowerUpType
{
    ExtraShooter = 1,
    Health = 2,
    NewProjectile = 3
};
public class PowerUp :ShipStat
{
    [SerializeField] PowerUpType powerUpType;
    [SerializeField] Object content;

    public static UnityEvent<PowerUpType, Object> onPowerUpAcquireEvent;

    // Start is called before the first frame update
    protected override void GetHit(int pDamage)
    {
        base.GetHit(pDamage);

        onPowerUpAcquireEvent.Invoke(powerUpType, content);
        gameObject.SetActive(false);
    }
}
