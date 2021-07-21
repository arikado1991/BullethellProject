using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySidewayMovementController : EnemyControllerMovingForward    
 
    // Start is called before the first frame update
{   const float C_VERTICAL_STEP = 1.2f;

    [SerializeField]
    protected int mHorizontalDirection;
    [SerializeField]
    protected float mVerticalRemainingDistance;

    void Reset ()
    {
        mHorizontalDirection = 1;

        mVerticalRemainingDistance = -C_VERTICAL_STEP;

    }

    protected override void OnEnable ()
    {
        base.OnEnable();
        Reset();
    }
    protected void Update ()
    {
        CheckEnemyFled();
        if (mVerticalRemainingDistance == -C_VERTICAL_STEP) //move left or right
        {
            transform.position += mMoveSpeed * mHorizontalDirection * Vector3.right * Time.deltaTime;
            if (transform.position.x * Mathf.Sign (mHorizontalDirection) > Const.C_HORIZONTAL_LIMIT)
            {
                mVerticalRemainingDistance = C_VERTICAL_STEP;
            }
        }
        else if (mVerticalRemainingDistance > 0) // move down 
        {
            mVerticalRemainingDistance -= mMoveSpeed * Time.deltaTime;
            transform.position += mMoveSpeed * Vector3.down * Time.deltaTime;
        }   
        else  //Switch direction
        {
            mHorizontalDirection *= -1;
            mVerticalRemainingDistance = -C_VERTICAL_STEP;
        }
    }
}
