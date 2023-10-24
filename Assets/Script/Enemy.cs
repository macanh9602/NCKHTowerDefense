using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 target;
    private void Start()
    {
        target = BuildingManager.Instance.getCastleCenter();
    }
    public static Enemy Create(Vector3 position)
    {
        Transform prfEnemy = Resources.Load<Transform>("Ghost").transform;
        Transform _enemy = Instantiate(prfEnemy,position,Quaternion.identity);
        Enemy enemy = _enemy.gameObject.GetComponent<Enemy>();
        if (BuildingManager.Instance.getCastleCenter() != null)
        {
            enemy.FlipFace(_enemy, BuildingManager.Instance.getCastleCenter());
        }      
        return enemy;
    }
    private void Update()
    {
        float speed = 0.1f;

            transform.position = Vector3.Lerp(transform.position, BuildingManager.Instance.getCastleCenter(), speed * Time.fixedDeltaTime);
           // Debug.Log(BuildingManager.Instance.getCastleCenter());     
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "CastleCenter")
        {
            BuildingHealth buildingHealth = collision.gameObject.GetComponent<BuildingHealth>();
            buildingHealth.OnDamage(20f);
            buildingHealth.IsHealthChange();
            
            Destroy(gameObject);
        }
    }
    public void FlipFace(Transform enemy , Vector3 target)
    {                
        if (enemy.position.x - target.x < 0)
        {
            enemy.gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
