using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        time -= Time.deltaTime;
        if (time < 0)
        {
            time = coinData.timeMax;
            CoinManager.Instance.addCoin(coinData.resource,buildingType);
        }
    }
}
