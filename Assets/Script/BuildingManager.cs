using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager Instance { get; private set; }
    BuildingTypeSO currentBuildingTypeSO;
    BuildingTypeHolder currentBuildingTypeHolder;
    //public BuildingConstruction buildingConstruction;
    public event EventHandler<OnChangeBuildingEventArg> OnChangeBuilding;
    public class OnChangeBuildingEventArg : EventArgs
    {
        public BuildingTypeSO BuildingTypeSO;
        public BuildingTypeHolder BuildingTypeHolder;
    }
    private void Start()
    {
        Instance = this;
        //buildingTypeList = Resources.Load<BuildingTypeListSO>("BuildingTypeListSO");
        //buildingTypeSO = buildingTypeList._ListBuilding[0];
    }
    private void Update()
    {
        
    }

    //xay dung ham sinh ra toa nha
    public void Build(BuildingTypeSO buildingType,Vector3 BuildingPos)
    {
        Transform building = Instantiate(buildingType.pref, BuildingPos, Quaternion.identity);
        building.SetParent(currentBuildingTypeHolder.gameObject.transform);
        building.GetComponent<SpriteRenderer>().sprite = buildingType.sprite[Random.Range(0,buildingType.sprite.Length)];
        building.GetComponent<CoinGenerator>().buildingType = buildingType;

    }
    public BuildingTypeSO GetCurrentBuildingTypeSO()
    {
        return currentBuildingTypeSO;
    }
    public void setCurrentBuildingTypeSO(BuildingTypeSO building)
    {
        currentBuildingTypeSO = building;
        OnChangeBuilding?.Invoke(this, new OnChangeBuildingEventArg
        {
            BuildingTypeSO = currentBuildingTypeSO,
            BuildingTypeHolder = currentBuildingTypeHolder
        }) ;
    } 
    public BuildingTypeHolder GetBuildingTypeHolder()
    {
        return currentBuildingTypeHolder;
    }
    public void setCurrentBuildingTypeHolder(BuildingTypeHolder buildingTypeHolder)
    {
        currentBuildingTypeHolder = buildingTypeHolder;
    }

}
