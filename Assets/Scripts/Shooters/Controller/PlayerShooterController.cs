using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooterController : ShooterController
{
    [SerializeField]
    float mCooldown = 0.5f;
    float mCurrentCooldown = 0f;

    protected override void Awake()
    {
        base.Awake();
        mTag = Tag.Player;
    }
    override protected void OnEnable()
    {
        base.OnEnable();
        mCurrentCooldown = 0f;
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
}
