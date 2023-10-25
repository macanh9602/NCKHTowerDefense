using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDefense : MonoBehaviour
{
    public Transform arrowStartPos;
    public float time;
    [SerializeField] float timeMax;
    [SerializeField] TowerDefenseSO tower;
    //private Vector3?abc;
    private void Start()
    {
        timeMax = 0.2f;
        time = timeMax;
       // tower = transform.gameObject.GetComponent<CoinGenerator>().buildingType;
       //if(abc != null)
       // {
       //     abc = null;
       // }
       // Vector3 a = abc.Value;
    }
    private void Update()
    {
        CheckEnemy();
    }
    public void CheckEnemy()
    {
        time -= Time.deltaTime;
        if(time < 0)
        {
            time = timeMax;
            //Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, );
        }
    }
}
