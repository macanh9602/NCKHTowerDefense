using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//GO BuildingConstruction (qua trinh thi cong toa nha)
//tao thanh loading trong 5f, sau 5f thi destroy this gameobject va tao Build
public class BuildingConstruction : MonoBehaviour
{
    public static BuildingConstruction Create(Vector3 position, BuildingTypeSO buildingType)
    {        
        Transform pfBuildingConstruction = Resources.Load<Transform>("BuildingConstruction");
        pfBuildingConstruction = Instantiate(pfBuildingConstruction,position,Quaternion.identity);
        BuildingConstruction buildingConstruction = pfBuildingConstruction.gameObject.GetComponent<BuildingConstruction>();
        buildingConstruction.Setup(3f,buildingType);
        return buildingConstruction;
    }

   // public Material material;
    private BuildingTypeSO buildingType;
    private float time;
    private float timeBuild;
    private void Start()
    {
        //timeBuild = BuildingManager.Instance.GetCurrentBuildingTypeSO().timeBuild;
    }

    private void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0 )
        {
            //transform.Find("clip1").GetComponent<Animator>().enabled = false;
            BuildingManager.Instance.Build(buildingType, this.transform.position);
            Destroy(gameObject);
        }
        //material.SetFloat("_Progress", getConstructionTimerNormalize());
        
    }
    public void Setup(float timeBuild,BuildingTypeSO buildingType)
    {
        this.buildingType = buildingType;
        this.timeBuild = timeBuild;
        time = timeBuild;
        
    }
    public float getConstructionTimerNormalize()
    {
        return time / timeBuild;
    }
}
