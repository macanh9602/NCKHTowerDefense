using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class TowerDefense : MonoBehaviour
{
    //public Transform arrowStartPos;

    //public float timeCheck; // time check enemy
    //[SerializeField] float timeCheckMax = .2f;

    //public float timeSpeed;
    //public float timeSpeedMax;

    //[SerializeField] TowerDefenseSO tower;
    //[SerializeField] Transform arrowPos;

    //private Enemy enemyTarget;
    ////private Vector3?abc;
    //private void Start()
    //{
    //    timeCheck = timeCheckMax;
    //    tower = GetComponent<ThisTypeOfBuilding>().towerDefense;
    //    timeSpeedMax = tower.SpawnArrowPerTime;
    //}
    //private void Update()
    //{
    //    //check target
    //    CheckEnemy();      
    //    //if target !null thi  create arrow
    //    // create arrow
    //    DoCreate();          
    //}
    //public void CheckEnemy()
    //{
    //    Collider2D[] colliders;
    //    timeCheck -= Time.deltaTime;
    //    if (timeCheck < 0)
    //    { 
    //        //phat hien cac enemy moi 0.2f
    //        colliders = Physics2D.OverlapCircleAll(transform.position, tower.radiusATK, LayerMask.GetMask("Monster"));
    //        foreach(Collider2D collider in colliders)
    //        {
    //            Enemy enemy = collider.GetComponent<Enemy>();
    //            if(enemy is not null)
    //            {
    //                enemyTarget = enemy;
    //            }
    //            //else
    //            //{
    //            //    //lam cai j
    //            //    //enemyTarget co gia tri
    //            //}

    //        }
    //        timeCheck += timeCheckMax;
    //    }
    //}
    //public void DoCreate()
    //{
    //    if (enemyTarget is not null)
    //    {
    //        timeSpeed -= Time.deltaTime;
    //        timeSpeed = Mathf.Clamp(timeSpeed ,0,timeSpeedMax);
    //        if((timeSpeed <= 0))
    //        {
    //            //sinh mui ten
    //            ArrowController.Create(arrowPos.position, enemyTarget);
    //            timeSpeed += timeSpeedMax;
    //        }

    //    }
    //}

    //check enemy
    //sinh arrow
    Enemy targetEnemy;
    TowerDefenseSO tower;
    private float timeCheck;
    private float timeCheckMax = .2f;

    private float timeSpawnDistance;
    private float timeSpawnDistanceMax;

    [SerializeField] Transform PosSpawn;
    private void Start()
    {
        tower = GetComponent<ThisTypeOfBuilding>().towerDefense;
    }
    public void Update()
    {
        timeSpawnDistanceMax = tower.SpawnArrowPerTime;
        CheckEnemy();
        SpawnArrow();
    }
    public void CheckEnemy()
    {
        timeCheck -= Time.deltaTime;
        if(timeCheck <= timeCheckMax)
        {
            timeCheck += timeCheckMax;
            //check now
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, tower.radiusATK, LayerMask.GetMask("Monster"));
            //tao vong lap cac colli enemy
            foreach(Collider2D collider in colliders)
            {
                //tao enemy moi , gan no voi collider
                Enemy enemy = collider.gameObject.GetComponent<Enemy>();
                //gan enemyTarget vao 1 trong enemy tuong ung collider trong colliders[] theo dk
                //if(enemy is null)
                //{
                    //chua co thi gan
                    targetEnemy = enemy;
                //}
                //else
                //{
                //    //khoang cach voi doi tuong voi target thu i
                //    float iDistance = Vector3.Distance(transform.position , targetEnemy.transform.position);
                //    //khoang cach voi doi tuong voi target thu j
                //    float jDistance = Vector3.Distance(transform.position , enemy.transform.position);
                //    //co roi thi thay doi theo dieu kien la khoang cach
                //    if(jDistance < iDistance)
                //    {
                //        targetEnemy = enemy;
                //    }
                //}
            }

            //if(colliders.Length > 0 )
            //{
            //    targetEnemy = colliders[0].gameObject.GetComponent<Enemy>();
            //}

        }
    }
    public void SpawnArrow()
    {
        if (targetEnemy is not null)
        {
            timeSpawnDistance -= Time.deltaTime;
            if (timeSpawnDistance <= 0)
            {
                timeSpawnDistance = timeSpawnDistanceMax;
                //sinh now
                ArrowController.Create(PosSpawn.position, targetEnemy);
            }
        }
        
    }
}

