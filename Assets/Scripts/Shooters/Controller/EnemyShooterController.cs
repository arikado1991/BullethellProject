using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyShooterController : ShooterController
{
    protected const float C_STANDARD_ENEMY_SHOOT_COOLDOWN = 2.5f;
    protected float mCooldown = 0;
    // Start is called before the first frame update

    // Update is called once per frame

    protected override void Awake()
    {
        mTag = Tag.Enemy;
        base.Awake();
        
    }
    void Update()
    {
        
        if (mCooldown < 0)
        {
            mOnShootEvent.Invoke();
            ResetCooldown();
        }
        else
        {
            mCooldown -= Time.deltaTime;
        }
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        ResetCooldown ();
    }

    protected virtual void ResetCooldown ()
    {
        mCooldown = Random.Range (0, C_STANDARD_ENEMY_SHOOT_COOLDOWN);
    }
}
