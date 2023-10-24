using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] BuildingHealth BuildingHealth;
    private void Start()
    {
        BuildingHealth.OnHealthChange += BuildingHealth_OnHealthChange;
    }

    private void BuildingHealth_OnHealthChange(object sender, System.EventArgs e)
    {
        EditHealthBar();
    }

    public void EditHealthBar()
    {
        
        transform.Find("Bar").localScale =  new Vector3( BuildingHealth.getHealthNormalize(),1,1);
    }



}
