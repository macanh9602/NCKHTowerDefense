using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTypeHolder : MonoBehaviour
{
    [SerializeField] BuildingTypeSO buildingType;
    ResourceSO resource;
    [SerializeField] bool IsPress = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            if (Input.GetKey(KeyCode.Space) && IsPress is false)
            {
               IsPress = true;
                //tao ra toa nha tu ham trong BuildingManager
                BuildingManager.Instance.Build(buildingType, this.transform.position);
                resource = CoinManager.Instance.GetResourceSO();
                CoinManager.Instance.UseMoneyToBuild(resource, buildingType);
                //tru tien build 
                //tao effect build
                
            }
        }
    }
}
