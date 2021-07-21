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
        Projectile newProjectTile;
        try
        {
            newProjectTile = EnemySpawner.Instance().SpawnObject(transform.position, mProjectile, transform.up).GetComponent<Projectile>();
            newProjectTile.transform.up = transform.up;
            newProjectTile.SetTag(mTag);

            AudioManager.onPlaySoundRequest.Invoke("Cannon");
        }
        catch (System.NullReferenceException)
        {
            Debug.LogError("No projectile component is attached to the projectile Prefab");
        }
       

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
