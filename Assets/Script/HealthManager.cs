using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] Transform target;
    private float healthMax;
    private float health;
    private void Start()
    {
        healthMax = target.GetComponent<CoinGenerator>().buildingType.health;
        health = healthMax;
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ReceiveDamage(20f);
           
        }
        if(health <= 0)
        {
            Destroy(target);
        }
        transform.Find("Bar").GetComponent<Transform>().localScale =  new Vector3( getHealthNormalize(),1,1);
    }
    public void ReceiveDamage(float damage)
    {
        health -= damage;
    }

    public float getHealthNormalize()
    {
        return health/healthMax;
    }

}
