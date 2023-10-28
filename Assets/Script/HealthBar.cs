using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] HealthSysterm type;
    private void Start()
    {
        type.OnHealthChange += BuildingHealth_OnHealthChange;
    }

    private void BuildingHealth_OnHealthChange(object sender, System.EventArgs e)
    {
        EditHealthBar();
    }

    public void EditHealthBar()
    {
        
        transform.Find("Bar").localScale =  new Vector3(type.getHealthNormalize(),1,1);
    }



}
