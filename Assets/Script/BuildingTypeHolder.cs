using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BuildingTypeHolder : MonoBehaviour
{
    [SerializeField] BuildingTypeSO buildingType;
    ResourceSO resource;
    [SerializeField] bool IsPress = false;
    //[SerializeField] GhostManager ghostManager;

    //[SerializeField] Transform circleLoading;

    //public event EventHandler OnStandBuilding;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {              
            BuildingManager.Instance.setCurrentBuildingTypeSO(buildingType);

            BuildingManager.Instance.setCurrentBuildingTypeHolder(this);

           if(IsPress is false)
            {
                //OnStandBuilding?.Invoke(this, EventArgs.Empty);
                if (Input.GetKey(KeyCode.Space))
                {
                    
                    resource = CoinManager.Instance.GetResourceSO();
                    //check du tien khong
                    if (CoinManager.Instance.isEnoughMoney(resource, buildingType) == true)
                    {
                        IsPress = true;
                        //BuildingManager.Instance.buildingConstruction.getTimeNormalize();
                        //tao ra toa nha tu ham trong BuildingManager
                        //BuildingManager.Instance.Build(buildingType, this.transform.position);
                        //tao ra gameobject chua buildingconstruction                      
                        BuildingConstruction building = BuildingConstruction.Create(this.transform.position, buildingType);                      
                        transform.Find("sprite").gameObject.SetActive(false);
                        //tru tien build 
                        CoinManager.Instance.UseMoneyToBuild(resource, buildingType);
                        //get effect build
                    }
                    //else Debug.Log("ko du tien");
                }
                         
            }
            else
            {
                //OnStandBuilding = null;
            }
        }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            BuildingManager.Instance.setCurrentBuildingTypeSO(null);
            //OnStandBuilding = null;
        }
    }
    
}
