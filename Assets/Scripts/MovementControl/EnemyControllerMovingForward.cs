using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerMovingForward : MovementController
{
    // Start is called before the first frame update
    [SerializeField]
    float mMoveSpeed = 1f;
    void OnEnable () 
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -6)
        {
            GameObject.Destroy (gameObject);
            return;
        }

        transform.position += transform.up * mMoveSpeed * Time.deltaTime;
    }
}
