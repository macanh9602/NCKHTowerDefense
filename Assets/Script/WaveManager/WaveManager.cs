using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [Tooltip("List wave in this scene")]
    [SerializeField][NonReorderable] List<Wave> waves = new List<Wave>();
    [Tooltip("CurrentWave")]
    public int waveNumber = -1;
    public int waveCount => waves.Count;
    public float WaveBeforeNextWave = 20f;

    private void Start()
    {
        waveNumber += 1;
        
    }
    private void Update()
    {
        StartSpawnWave(waveNumber);
    }
    public void StartSpawnWave(int index)
    {
        //chay wave dau tien de
        waves[index].Update();
    }
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
