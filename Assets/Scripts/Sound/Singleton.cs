using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    private static Singleton mInstance;
    protected void Awake()
    {

        if (mInstance != null)
        {
            GameObject.Destroy (gameObject);
        }
    }

    public static Singleton Instance() 
    {
        if (mInstance == null)
        {
            throw new System.NullReferenceException();
        }
        return mInstance;
    }
}
