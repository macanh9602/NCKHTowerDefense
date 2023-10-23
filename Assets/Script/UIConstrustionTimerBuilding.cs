using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//UI load time to build
public class UIConstrustionTimerBuilding : MonoBehaviour
{
    [SerializeField] BuildingConstruction buildingConstruction;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Find("Image").GetComponent<Image>().fillAmount = buildingConstruction.getConstructionTimerNormalize();
        
    }

}
