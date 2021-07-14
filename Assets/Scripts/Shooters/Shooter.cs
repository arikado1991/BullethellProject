using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] Projectile mProjectile;
    // Start is called before the first frame update

    [SerializeField] int damage = 1;
    [SerializeField] float cooldown;
    float remainingCooldown;
    Tag mTag;


    void Start()
    {
        remainingCooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (remainingCooldown > 0)
        {
            remainingCooldown -= Time.deltaTime;
        }
    }

    public void Shoot  () 
    {
        if (remainingCooldown > 0)
            return;

        Projectile newProjectTile = GameObject.Instantiate (mProjectile, transform.position, Quaternion.identity);
        newProjectTile.transform.up = transform.up;
        newProjectTile.SetTag (mTag);

        remainingCooldown = cooldown;
    
    }

    public void SetTag (Tag pTag)
    {
        mTag = pTag;
    }

    public Tag GetTag (Tag pTag)
    {
        return mTag;
    }
}
