using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    public enum State
    {
        WaitForNextWave,
        SpawnEnemy
    }
    private State state;
    [Tooltip("List wave in this scene")]
    //[SerializeField][NonReorderable] List<Wave> waves = new List<Wave>();
    //[Tooltip("CurrentWave")]
    public int waveNumber = 0;
    //public int waveCount => waves.Count;
    public float WaitBeforeNextWave;
    public float RemainEnemyAmount;
    float WaitBeforeNextEnemy;
    public EnemyTypeSO enemy;
    public Transform pos;
    private void Start()
    {
        WaitBeforeNextWave = 10f;
        state = State.WaitForNextWave;
    }
    private void Update()
    {
        Debug.Log(state);
        switch(state)
        {
            case State.WaitForNextWave:
                WaitBeforeNextWave -= Time.deltaTime;
                if (WaitBeforeNextWave < 0)
                {
                    SpawnWave();
                    waveNumber++;
                }
                break;
            case State.SpawnEnemy:
                if (RemainEnemyAmount > 0)
                {
                    WaitBeforeNextEnemy -= Time.deltaTime;
                    if (WaitBeforeNextEnemy < 0)
                    {
                        WaitBeforeNextEnemy = 5;
                        Enemy.Create(pos.position, enemy);
                        RemainEnemyAmount--;

                        if(RemainEnemyAmount <= 0)
                        {
                            state = State.WaitForNextWave;
                        }
                    }
                }

                break;
        }
    }
    public void SpawnWave()
    {
        WaitBeforeNextWave = 20f;
        RemainEnemyAmount = 5f;
        state = State.SpawnEnemy;
    }
    public State GetState()
    {
        return state;
    }
    //private void Start()
    //{
    //    waveNumber += 1;

    //}
    //private void Update()
    //{
    //    if (waveNumber >= waveCount)
    //    {
    //        //stop
    //    }
    //    WaitBeforeNextWave -= Time.deltaTime;
    //    while (WaitBeforeNextWave > 0)
    //    {
    //        return;
    //    }
    //    StartSpawnWave(waveNumber);

    //}
    //public void StartSpawnWave(int index)
    //{
    //    //chay wave dau tien de
    //    waves[index].Update();
    //    WaitBeforeNextWave = 20f;
    //}
    //IEnumerator StartWave()
    //{
    //    waveNumber++;
    //    while (WaveBeforeNextWave > 0)
    //    {
    //        waveNumber = 0;
    //        waves[waveNumber].Update();
    //        WaveBeforeNextWave -= Time.deltaTime;
    //        yield return null;
    //    }
    //    Debug.Log("halo1");
    //    WaveBeforeNextWave = 2f;


    //}

}
