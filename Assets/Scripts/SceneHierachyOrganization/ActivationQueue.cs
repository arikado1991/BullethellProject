using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationQueue : MonoBehaviour
{
    [SerializeField]  GameObject[] mQueue;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine ("ActivateInOrder");   
    }

    IEnumerator ActivateInOrder()
    {
        foreach (GameObject o in mQueue)
        {
           // o.transform.parent = null;
            o.SetActive(true);
            o.transform.parent = null;
            yield return new WaitForSeconds (0.2f);
        }
    }

}
