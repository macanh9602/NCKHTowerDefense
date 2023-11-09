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
    public float TimeWaitToNextSpawn = 10f;
    public void Update()
    {
        for(int i = 0; i < lstSpawn.Count; i++)
        {
            lstSpawn[i].Update();
            while (TimeWaitToNextSpawn > 0)
            {
                Debug.Log("halo2");
                TimeWaitToNextSpawn -= Time.deltaTime;
            }
            TimeWaitToNextSpawn = 10f;

        }
    }

   
}
