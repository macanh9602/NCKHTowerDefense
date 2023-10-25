using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy Create(Vector3 position, EnemyTypeSO enemyType)
    {
        Transform prfEnemy = Resources.Load<Transform>("Ghost").transform;
        Transform _enemy = Instantiate(prfEnemy, position, Quaternion.identity);
        Enemy enemy = _enemy.gameObject.GetComponent<Enemy>();
        if (BuildingManager.Instance.getCastleCenter() != null)
        {
            enemy.FlipFace(_enemy);
        }
        return enemy;
    }

    private Vector3 target;
    private void Start ()
    {
        //if (BuildingManager.Instance.getCastleCenter() != null)
        //{
        //    target = BuildingManager.Instance.getCastleCenter().transform.position;
        //    Debug.Log(target);
        //}
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position,20f,LayerMask.GetMask("Building"));
        if(collider.Length >0)
        {
            target = collider[0].gameObject.transform.position;
        }
        
        Debug.Log(collider[0].gameObject.name);

    }
    
    private void Update()
    {
        float speed = 0.1f;
        if(target != null)
        {
            transform.position = Vector3.Lerp(transform.position, target, speed * Time.fixedDeltaTime);
        }
        // Debug.Log(BuildingManager.Instance.getCastleCenter());     
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            BuildingHealth buildingHealth = collision.gameObject.GetComponent<BuildingHealth>();
            buildingHealth.OnDamage(20f);
            buildingHealth.IsHealthChange();
            
            Destroy(gameObject);
        }
    }
    public void FlipFace(Transform enemy)
    {
        if (enemy.position.x - target.x < 0)
        {
            enemy.gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0, 180, 0);
        }
    }
    
}
