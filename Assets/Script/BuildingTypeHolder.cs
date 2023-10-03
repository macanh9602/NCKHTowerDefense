using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTypeHolder : MonoBehaviour
{
    public BuildingTypeSO buildingType;
    bool IsPress = true;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            Debug.Log("Halo");
            if (Input.GetKey(KeyCode.Space) && IsPress)
            {
               IsPress = false;
                Debug.Log("touch");
                BuildingManager.Instance.Build(buildingType, this.transform.position);
            }
        }
    }
}
