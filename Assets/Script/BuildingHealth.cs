using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHealth : MonoBehaviour
{
    private float healthMax;
    private float health;
    public event EventHandler OnHealthChange;

    private void Awake()
    {
        healthMax = transform.GetComponent<CoinGenerator>().buildingType.health ;
        health = healthMax;
    }
    private void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    OnDamage(20f);
        //    OnHealthChange?.Invoke(this, EventArgs.Empty);
        //}
    }
    public float getHealthNormalize()
    {
        return health/healthMax;
    }

    public void OnDamage(float damage )
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, healthMax);
        if(health == 0 )
        {
            Destroy(gameObject);
        }
    }
    public void IsHealthChange()
    {
        OnHealthChange?.Invoke(this, EventArgs.Empty);
    }
}
