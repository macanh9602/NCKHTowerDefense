using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] ResourceSO resource;
    public static CoinManager Instance { get; private set; }
    Dictionary<ResourceSO, int> _coin = new Dictionary<ResourceSO, int>();
    public void Start()
    {
        Instance = this;
        _coin[resource] = 3;
    }
    public void addCoin(ResourceSO resource ,BuildingTypeSO buildingType)
    {
        _coin[resource] += buildingType.costToBuildOrUpgrate;
    }
    private void Update()
    {
        Debug.Log(getCoin(resource));
    }
    public int getCoin(ResourceSO resource)
    {
        return _coin[resource];
    }
    public void UseMoneyToBuild(ResourceSO resource, BuildingTypeSO buildingType)
    {
        _coin[resource] -= buildingType.costToBuildOrUpgrate;
    }
}
