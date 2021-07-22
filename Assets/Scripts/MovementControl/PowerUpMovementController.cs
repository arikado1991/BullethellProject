using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMovementController : MovementController
{
    const float C_CHANGE_DIRECTION_MAX_COOLDOWN = 2f;
    Vector3 mCurrentDirection;
    [SerializeField] float mMoveSpeed;

    float mChangeDirectionCooldown;
    // Start is called before the first frame update
    private void OnEnable()
    {
        ChangeDirection();
        mChangeDirectionCooldown = C_CHANGE_DIRECTION_MAX_COOLDOWN;
    }

    // Update is called once per frame
    void Update()
    {
        if (mChangeDirectionCooldown <= 0)
        {
            ChangeDirection();
        }    

        transform.position += mCurrentDirection * mMoveSpeed * Time.deltaTime;
        mChangeDirectionCooldown -= Time.deltaTime;
        
    }

    void ChangeDirection()
    {
        if (Vector3.SqrMagnitude(transform.position) > 3)
        {
            mCurrentDirection = -transform.position + GenerateRandomDirection() * 0.25f;
            mCurrentDirection.Normalize();

            mChangeDirectionCooldown = C_CHANGE_DIRECTION_MAX_COOLDOWN;
        }

        else if (Vector3.SqrMagnitude(transform.position) < 1)
        {
            mCurrentDirection = GenerateRandomDirection();
            mChangeDirectionCooldown = C_CHANGE_DIRECTION_MAX_COOLDOWN;
        }

    }

    Vector3 GenerateRandomDirection ()
    {
        Vector3 generatedDirection = Random.insideUnitSphere;
        generatedDirection.z = 0;
        generatedDirection.Normalize();
        return generatedDirection;
    }
}
