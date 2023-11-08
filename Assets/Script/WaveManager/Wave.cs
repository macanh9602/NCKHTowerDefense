using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Wave
{
    [Header("Reference")]
    [Tooltip("List enemies spawn in this wave")]
    [SerializeField][NonReorderable] List<Spawn> lstSpawn;
    private float TimeWaitToNextSpawn = 10f;
    public void Update()
    {
        for(int i = 0; i < lstSpawn.Count; i++)
        {
            while(TimeWaitToNextSpawn > 0)
            {
                TimeWaitToNextSpawn -= Time.deltaTime;
            }
            lstSpawn[i].Update();
            Debug.Log("halo2");
            TimeWaitToNextSpawn = 10f;

        }
    }

   
}
