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
    public int enemyDieAmount;
    private int enemyRemainAmount;
    [Tooltip("EnemiesPerSecond")]
    public float EnemiesPerSecond = 2f;
    [Tooltip("position spawn")]
    public Transform PosSpawn;
    //Random rnd = new Random();


    public void Update()
    {
        EnemiesPerSecond -= Time.deltaTime;
        while(EnemiesPerSecond > 0)
        {
            return;
        }
        EnemiesPerSecond = 2f;
        if(enemyBornAmount < enemyAmount )
        {
            Enemy enemy = Enemy.Create(PosSpawn.position, enemyTypeSO);
            enemyBornAmount++;            
        }


        //for(int i = 0; i < enemyAmount; i++)
        //{          
        //    EnemiesPerSecond -= Time.deltaTime;
        //    if(EnemiesPerSecond <0 )
        //    {
        //        EnemiesPerSecond = 1f;
        //        if(enemyBornAmount == enemyAmount)
        //        {
        //            return;
        //        }
        //        else
        //        {
        //            Enemy enemy = Enemy.Create(PosSpawn.position, enemyTypeSO);

        //            enemyBornAmount++;
        //        }         
        //        Debug.Log("enemyBorn" + enemyBornAmount);
        //    }

        //}
    }
    public void resetAtributeEnemies()
    {
        //khi nghuoi choi xong wave
         //khi wa        
    }
}
