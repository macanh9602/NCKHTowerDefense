using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTypeHolder : MonoBehaviour
{
    [SerializeField] BuildingTypeSO buildingType;
    ResourceSO resource;
    [SerializeField] bool IsPress = false;
    [SerializeField] GhostManager ghostManager;
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
                    IsPress = true;
                    //tao ra toa nha tu ham trong BuildingManager
                    BuildingManager.Instance.Build(buildingType, this.transform.position- new Vector3(0,0.2f,0));
                    transform.Find("sprite").gameObject.SetActive(false);
                    resource = CoinManager.Instance.GetResourceSO();
                    //tru tien build 
                    CoinManager.Instance.UseMoneyToBuild(resource, buildingType);
                    //tao effect build

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
