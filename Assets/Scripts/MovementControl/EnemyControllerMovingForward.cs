using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerMovingForward : MovementController
{
    // Start is called before the first frame update
    [SerializeField]
    protected float mMoveSpeed = 1f;

    protected virtual void Reset()
    {

    }

    protected virtual void OnEnable () 
    {

    }

    // Update is called once per frame
    void Update()
    {

        CheckEnemyFled();
        transform.position += transform.up * mMoveSpeed * Time.deltaTime;
    }

    protected void CheckEnemyFled ()
    {
        if (transform.position.y < -Const.C_VERTICAL_LIMIT - 2)
        {
            EnemySpawner.onEnemyFledEvent.Invoke(this.GetComponent<ShipStat>());
            return;
        }
    }
}
