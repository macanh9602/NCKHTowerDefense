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
        //Debug.Log(e.BuildingTypeHolder);
        if (e.BuildingTypeSO != null)
        {
            if (e.BuildingTypeHolder = BuildingManager.Instance.GetBuildingTypeHolder())
            {
                Show(e.BuildingTypeSO);
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
        BuildingTypeHolder holder = BuildingManager.Instance.GetBuildingTypeHolder();
        transform.position = holder.gameObject.transform.position;

        transform.gameObject.SetActive(true);

        transform.Find("Ghost").GetComponent<SpriteRenderer>().sprite = buildingType.sprite[0];
    }
}
