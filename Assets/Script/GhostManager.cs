using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GhostManager : MonoBehaviour
{

    private void Start()
    {
        Hide();
        BuildingManager.Instance.OnChangeBuilding += Instance_OnChangeBuilding;

    }
    private void Instance_OnChangeBuilding(object sender, BuildingManager.OnChangeBuildingEventArg e)
    {
        e.BuildingTypeSO = BuildingManager.Instance.GetCurrentBuildingTypeSO();
        Debug.Log(e.BuildingTypeHolder);
        if(e.BuildingTypeSO != null)
        {
            int index = 0;
            if(e.BuildingTypeHolder = BuildingManager.Instance.GetBuildingTypeHolder())
            {
                if(index == 0)
                {
                    Show(e.BuildingTypeSO);
                    index = 1;
                }
                else
                {
                    Hide();
                }
            }

            

        }
        else
        {
            Hide();
        }
    }

    public void Hide()
    {
        transform.gameObject.SetActive(false);
    }

    public void Show(BuildingTypeSO buildingType)
    {
        transform.gameObject.SetActive(true);
        //sprite trong Child = sprite building pos
        buildingType = BuildingManager.Instance.GetCurrentBuildingTypeSO();
        transform.Find("Ghost").GetComponent<SpriteRenderer>().sprite = buildingType.sprite[0];
        //Set vi tri ghost = vi tri xay dung cong trinh
        //BuildingTypeHolder holder = BuildingManager.Instance.GetBuildingTypeHolder();
        //transform.position = holder.gameObject.transform.position;  
    }
    private void Update()
    {
        BuildingTypeHolder holder = BuildingManager.Instance.GetBuildingTypeHolder();
        transform.position = holder.gameObject.transform.position;  
    }


}
