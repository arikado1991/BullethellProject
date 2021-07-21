using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDestroy : MonoBehaviour
{
    [SerializeField] public  PowerUp dropPrefab;
    // Start is called before the first frame update
    void OnDisable()
    {
        IngameObjectManager.Instance().SpawnObject( transform.position, dropPrefab, transform.up);
        GameObject.Destroy(this);
    }
}
