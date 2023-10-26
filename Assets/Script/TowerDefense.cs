using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDefense : MonoBehaviour
{
    public Transform arrowStartPos;
    public float time;
    [SerializeField] float timeMax;

    public float time1;
    [SerializeField] float timeMax1;

    [SerializeField] TowerDefenseSO tower;
    [SerializeField] Transform arrowPos;

    private Enemy enemyTarget;
    //private Vector3?abc;
    private void Start()
    {
        timeMax = 0.2f;
        time = timeMax;

        timeMax1 = 0.5f;
        time1 = 0;
        tower = GetComponent<ThisTypeOfBuilding>().towerDefense;
       // tower = transform.gameObject.GetComponent<CoinGenerator>().buildingType;
       //if(abc != null)
       // {
       //     abc = null;
       // }
       // Vector3 a = abc.Value;
    }
    private void Update()
    {

        //check target
        //if target !null thi  create arrow
        // create arrow
        time -= Time.deltaTime;
        if (time < 0)
        {
            time = timeMax;
            //Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, );
            CheckEnemy();
        }
        DoCreate();

    }
    public void CheckEnemy()
    {
        //phat hien cac enemy moi 0.2f
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, tower.radiusATK, LayerMask.GetMask("Monster"));
        if (colliders.Length > 0)
        {
            if(enemyTarget = null)
            {
                enemyTarget = colliders[0].gameObject.GetComponent<Enemy>();
            } 
        }
    }
    public void DoCreate()
    {
        if (enemyTarget != null)
        {
            time1 -= Time.deltaTime;
            time1 = Mathf.Clamp(time1, 0, timeMax1);

            if (time1 == 0)
            {
                time1 = timeMax1;
                //sinh mui ten
                ArrowController.Create(arrowPos.position, enemyTarget);
            }
        }
        else
        {
            enemyTarget.transform.position = arrowStartPos.position;
            ArrowController.Create(arrowPos.position, enemyTarget);
        }
            
    }
}
