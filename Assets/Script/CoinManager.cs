using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] ResourceSO resource;
    public static CoinManager Instance { get; private set; }
    public Dictionary<ResourceSO, int> _coin = new Dictionary<ResourceSO, int>();
    //dung event de xu ly su kien OnChangeCoin
    public event EventHandler OnChangeCoin;
    public void Awake()
    {
        Instance = this;
        _coin[resource] = 5;
    }
    public void Start()
    {
        
        
    }
    public void addCoin(ResourceSO resource ,BuildingTypeSO buildingType)
    {
        _coin[resource] += buildingType.costToBuildOrUpgrate;
        OnChangeCoin?.Invoke(this, EventArgs.Empty);
    }
    public int getCoin(ResourceSO resource)
    {
        return _coin[resource];
    }
    public void UseMoneyToBuild(ResourceSO resource, BuildingTypeSO buildingType)
    {
        _coin[resource] -= buildingType.costToBuildOrUpgrate;       
    }
    public ResourceSO GetResourceSO()
    {
        return resource;
    }
    public bool isEnoughMoney(ResourceSO resource, BuildingTypeSO buildingType)
    {
        if (_coin[resource] - buildingType.costToBuildOrUpgrate >= 0) 

        return true;
        else return false;
    }
}
