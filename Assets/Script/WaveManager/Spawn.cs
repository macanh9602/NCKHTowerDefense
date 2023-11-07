using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Spawn
{
    [Header("Type of enemy")]
    public Transform enemy;
    [Header("enemyAmount")]
    public int enemyAmount;
    private int enemyBornAmount;
    private int enemyDieAmount;
    private int enemyRemainAmount;
    [Header("time distance born")]
    public float TimeDistanceBorn;
    [Header("position spawn")]
    public Transform[] PosSpawn;

}
