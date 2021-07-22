using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooterController : ShooterController
{
    [SerializeField]
    float mCooldown = 0.5f;
    float mCurrentCooldown = 0f;

    int mActivatedShooterCount = 1;

    protected override void Awake()
    {
        base.Awake();
        mTag = Tag.Player;
    }
    override protected void OnEnable()
    {
        base.OnEnable();
        mCurrentCooldown = 0f;
        PlayerPowerUpProcessor.onExtraShooterPowerUpAcquiredEvent.AddListener(AddShooter);
        PlayerShipStat.onPlayerGetHitEvent.AddListener(RemoveShooters);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        PlayerPowerUpProcessor.onExtraShooterPowerUpAcquiredEvent.RemoveListener(AddShooter);
        PlayerShipStat.onPlayerGetHitEvent.RemoveListener(RemoveShooters);
    }
    // Update is called once per frame
    void Update()
    {
        if (mCurrentCooldown > 0)
        {
            return;
        }
        if (Input.GetKey ("space"))
        {
            mOnShootEvent.Invoke();
        }
    }
    public void AddShooter()
    {
        try
        {
            mShooters[mActivatedShooterCount].gameObject.SetActive(true);
            mActivatedShooterCount++;
            ReadyAllShooters();
        }
        catch (System.IndexOutOfRangeException)
        {
            Debug.Log("The ship is already at max number of shooters."); 
        }
    }

    public void RemoveShooters()
    {
        for (int i = 1; i < mActivatedShooterCount;  i++)
        {
            mShooters[i].gameObject.SetActive(false);
            
        }
        mActivatedShooterCount = 1;
        ReadyAllShooters();
    }
}
