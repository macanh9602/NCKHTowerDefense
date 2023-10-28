using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSysterm : MonoBehaviour
{ 
    [SerializeField] float healthMax;
    private float health;
    public event EventHandler OnHealthChange;

    private void Awake()
    {
        //healthMax = transform.GetComponent<CoinGenerator>().buildingType.health ;
        health = healthMax;
    }
    private void Update()
    {

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
