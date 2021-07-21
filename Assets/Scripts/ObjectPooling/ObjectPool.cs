using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// A pool for a object that gets instantiated repeatedly throughout the game
/// </summary>

/// <summary>
/// Derived monobehavior class that sends out event allowing its ObjectPool to retrieve it.
/// </summary>


public class ObjectPool : Object
{
    [SerializeField]
    Queue<PoolableObject> m_Pool;
    protected PoolableObject mPrefab;
    public bool canGrow = true;
    int cloneCount;

    /// <summary>
    /// Create a new object pool that produces soly one mPrefab
    /// </summary>
    /// <returns>The init.</returns>
    /// <param name="newPrefab">Gameobject blueprint.</param>
    /// <param name="size">Initial size of the pool.</param>
    public void Init(PoolableObject newPrefab, int size)
    {
        m_Pool = new Queue<PoolableObject>(size);
        cloneCount = 0;
        mPrefab = newPrefab;
        for (int i = 0; i < size; i++)
        {
            PoolableObject obj = InstantiateObject();
            obj.gameObject.SetActive(false);

        }

    }
    /// <summary>
    /// Make a new clone and add it into the queue
    /// </summary>
    /// <returns>The object.</returns>
    private PoolableObject InstantiateObject () 
    {
        PoolableObject obj = GameObject.Instantiate(mPrefab);
        obj.name = string.Format("{0} #{1}", mPrefab.name, cloneCount);

       // obj.SubscribeOnDisable (RetrieveObject);

        
        m_Pool.Enqueue(obj);
        cloneCount++;
        return obj;
    }

    /// <summary>
    /// Return an object from the queue, clone more if needed
    /// </summary>
    /// <returns>The object.</returns>
    public PoolableObject GetObject()
    {
        if (m_Pool.Count == 0)
        {
            InstantiateObject();
        }
        PoolableObject pooledObject = m_Pool.Dequeue();
        pooledObject.gameObject.SetActive(true);
        pooledObject.onPoolableObjectDisableEvent += RetrieveObject;

        return pooledObject; 
    }

    /// <summary>
    /// Retrieve the object after it is disabled
    /// </summary>
    /// <param name="obj">Object.</param>
    public void RetrieveObject (PoolableObject obj) 
    {

        m_Pool.Enqueue(obj);
        obj.onPoolableObjectDisableEvent -= RetrieveObject;
    }

    void SetPrefab (PoolableObject newPrefab)
    {
        mPrefab = newPrefab;
    }

}


