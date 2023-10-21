using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//pref building
public class CoinGenerator : MonoBehaviour
{
    public BuildingTypeSO buildingType;
    [SerializeField] CoinData coinData;
    float time;
    private void Start()
    {
        time = coinData.timeMax;
    }
    private void Update()
    {
        if (buildingType.nameBuilding == "House")
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                time = coinData.timeMax;
                if (coinData.resource != null)
                {
                    CoinManager.Instance.addCoin(coinData.resource, buildingType);
                }

            }
        }
        
    }
}
