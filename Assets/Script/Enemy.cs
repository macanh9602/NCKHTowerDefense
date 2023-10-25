using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy Create(Vector3 position, EnemyTypeSO enemyType)
    {
        Transform prfEnemy = Resources.Load<Transform>("Ghost").transform;
        Transform _enemy = Instantiate(prfEnemy, position, Quaternion.identity);
        Enemy enemy = _enemy.gameObject.GetComponent<Enemy>();
        //if (BuildingManager.Instance.getCastleCenter() != null)
        //{
        enemy.CheckTarget();
        enemy.FlipFace(_enemy);
        //}
        return enemy;
    }

    private Transform target;
    private Rigidbody2D rb;
    private void Start ()
    {
        //if (BuildingManager.Instance.getCastleCenter() != null)
        //{
        //    target = BuildingManager.Instance.getCastleCenter().transform.position;
        //    Debug.Log(target);
        //}
        //CheckTarget();
        rb = GetComponent<Rigidbody2D>();
    }

    private void CheckTarget()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 30f, LayerMask.GetMask("Building"));
        if (collider.Length > 0)
        {
            target = collider[0].gameObject.transform;
        }
        else
        {
            target = transform;
        }

        Debug.Log(target.gameObject.name);
    }

    private void Update()
    {
        
        if(target != null)
        {
            Vector3 vectorNormalize = (target.position - transform.position).normalized;
            float speed = 2f;
            rb.velocity = vectorNormalize * speed;
        }
        else
        {
            CheckTarget();
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
        if (enemy.position.x - target.position.x < 0)
        {
            enemy.gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0, 180, 0);
        }
    }
    
}
