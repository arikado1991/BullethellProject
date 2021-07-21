using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;



public class Projectile : PoolableObject
{
    [SerializeField] float moveSpeed;

    [SerializeField] int damage;
    // Start is called before the first frame update
    [SerializeField] Tag mTag;
    void Start()
    {

    }

    public virtual void SetTag(Tag pTag)
    {
        mTag = pTag;
    }

    public Tag GetTag()
    {
        return mTag;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        transform.position += transform.up * moveSpeed * Time.deltaTime;
        if (Mathf.Abs(transform.position.y) > Const.C_VERTICAL_LIMIT + 2)
        {
            gameObject.SetActive(false);
        }
    }


    virtual protected void OnCollisionEnter2D(Collision2D other)
    {


        Tag collidedTag = Tag.Unassigned;
        try
        {
            collidedTag = other.gameObject.GetComponent<ShipStat>().GetTag();
        }
        catch (NullReferenceException)
        {
            try
            {
                collidedTag = other.gameObject.GetComponent<Projectile>().GetTag();
            }
            catch (NullReferenceException) { }
        }

        if (collidedTag != Tag.Unassigned && (int)mTag * (int)collidedTag < 0)
        {


            Debug.Log(string.Format("Proj tag: {0}, hit tag: {1}", mTag, collidedTag));
            other.gameObject.SendMessage("GetHit", damage);
            gameObject.SetActive(false);
        }


    }
    public void GetHit(int damage)
    {

    }
}
