using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;



public class Projectile : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    [SerializeField] int damage;
    float lifeSpan = 5;
    // Start is called before the first frame update
    [SerializeField] Tag mTag;
    void Start()
    {

    }

    public virtual void SetTag(Tag pTag)
    {
        mTag = pTag;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        transform.position += transform.up * moveSpeed * Time.deltaTime;
        lifeSpan -= Time.deltaTime;
        if (lifeSpan <= 0)
        {
            GameObject.Destroy (this.gameObject);
        }
    }


    virtual protected void OnCollisionEnter2D (Collision2D other)
    {
        try 
        {
            Tag collidedTag = other.gameObject.GetComponent<ShipStat>().GetTag();
            Debug.Log (string.Format ("Proj tag: {0}, hit tag: {1}", mTag, collidedTag));
            if (  (int) mTag * (int) collidedTag < 0)
            {
                Debug.Log ("Hit something");
                other.gameObject.SendMessage ("GetHit", damage );
                GameObject.Destroy (this.gameObject);
            }
        }
        catch (NullReferenceException e)
        {

        }
    }
}
