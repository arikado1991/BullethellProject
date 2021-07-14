using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;


public class PlayerController : MovementController
{
    private Rigidbody2D rb2d;
    [SerializeField]
    private float moveSpeed;
    UnityEvent onShootEvent;

    // Start is called before the first frame update
    void Awake()
    { 
        try
        {
            rb2d = transform.GetComponent<Rigidbody2D>();
        }
        catch (NullReferenceException e)
        {
            Debug.LogError (string.Format ("No rigidbody attached to object %s" ,this.name));
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        float newX = transform.position.x + Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        if (Math.Abs(newX) > Const.C_HORIZONTAL_LIMIT)
        {
            newX = ( (newX > 0) ? 1: (-1)  ) * Const.C_HORIZONTAL_LIMIT;
        }

        float newY = transform.position.y + Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        if (Math.Abs(newY) > Const.C_VERTICAL_LIMIT)
        {
            newY = ( (newY > 0) ? 1: (-1)  ) *  Const.C_VERTICAL_LIMIT;
        }

        transform.position = new Vector3 (newX, newY, 0);
    }   
}
