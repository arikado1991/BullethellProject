using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName="New Wave", menuName="WaveDescription")]
public class WaveDescription : ScriptableObject
{
    [SerializeField]
    public EnemySpawningInstruction[] mEnemySpawningInstruction;
}

[Serializable]
public struct EnemySpawningInstruction
{
    public ShipStat mEnemyController;
    public float mDelay; //may be time stamp is better?
} 