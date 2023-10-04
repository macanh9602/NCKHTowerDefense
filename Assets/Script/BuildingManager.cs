using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEditor;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager Instance { get; private set; }
    //[SerializeField] GameObject target;
    //BuildingTypeSO buildingTypeSO;
   // BuildingTypeListSO buildingTypeList;
    private void Start()
    {
        Instance = this;
        //buildingTypeList = Resources.Load<BuildingTypeListSO>("BuildingTypeListSO");
        //buildingTypeSO = buildingTypeList._ListBuilding[0];
    }
    private void Update()
    {
        //3if3lv:lv1 sinh ra 3 pref random
        //Vector3 BuildingPos = Extension.MousePosition();
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    Instantiate(buildingTypeSO.pref[Random.Range(0,buildingTypeSO.pref.Length)],BuildingPos,Quaternion.identity);
        //}
        //else if(Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    buildingTypeSO = buildingTypeList._ListBuilding[1];
        //    Instantiate(buildingTypeSO.pref[Random.Range(0, buildingTypeSO.pref.Length)], BuildingPos, Quaternion.identity);

        //}
        //else if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    buildingTypeSO = buildingTypeList._ListBuilding[2];
        //    Instantiate(buildingTypeSO.pref[Random.Range(0, buildingTypeSO.pref.Length)], BuildingPos, Quaternion.identity);
        //}
    }
    //xay dung ham sinh ra toa nha
    public void Build(BuildingTypeSO buildingType,Vector3 BuildingPos)
    {
        Transform building = Instantiate(buildingType.pref[Random.Range(0, buildingType.pref.Length)], BuildingPos, Quaternion.identity);
        building.GetComponent<CoinGenerator>().buildingType = buildingType;
    }
}
