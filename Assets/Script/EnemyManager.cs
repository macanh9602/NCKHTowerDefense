using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public EnemyListSO listEnemy;
    public EnemyTypeSO enemyType;
    // Start is called before the first frame update
    void Start()
    {
        listEnemy = Resources.Load<EnemyListSO>("EnemyListSO");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            enemyType = listEnemy.enemyList[0];
            Enemy.Create(Extension.MousePosition()  , enemyType);
        } 
    }
}

