using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct PowerUpRng
{
    public PowerUp powerUp;
    [Range(0, 99)]
    public int rate;
}

[CreateAssetMenu(fileName = "NewRNGTable", menuName = "PowerUpRngTable")]
public class PowerUpRngTable : ScriptableObject
{
    [SerializeField]
    public PowerUpRng[] mTable;
}

