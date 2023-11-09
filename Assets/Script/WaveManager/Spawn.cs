using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

[Serializable]
public class Spawn
{

    [Header("Reference")]
    [Header("Type of enemy")]
    public EnemyTypeSO enemyTypeSO;
    [Header("Atributes")]
    [Tooltip("enemyAmount")]
    public int enemyAmount;
    private int enemyBornAmount;
    private int enemyDieAmount;
    private int enemyRemainAmount;
    [Tooltip("EnemiesPerSecond")]
    public float EnemiesPerSecond ;    
    [Tooltip("position spawn")]
    public Transform PosSpawn;
    public float TimeNextSpawn;
    //Random rnd = new Random();


    public void Update()
    {
        
        TimeNextSpawn -= Time.deltaTime;
        while(TimeNextSpawn > 0)
        {
            return;
        }
        TimeNextSpawn = EnemiesPerSecond;
        if(enemyBornAmount < enemyAmount )
        {
            Enemy enemy = Enemy.Create(PosSpawn.position, enemyTypeSO);
            enemyBornAmount++;            
        }


    }
    public void resetAtributeEnemies()
    {
     
    }
}
