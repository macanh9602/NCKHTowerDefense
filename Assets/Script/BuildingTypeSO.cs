using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/BuildingTypeSO")]
public abstract class BuildingTypeSO : ScriptableObject
{
    public string nameBuilding;
    public Transform pref;
    public int level;
    public int costToBuildOrUpgrate;
    public int health;
    public Sprite[] sprite;
    public float timeBuild;

    //    public List<DefenderBuilding> defenders = new List<DefenderBuilding>();
    //    public List<FarmBuilding> farm = new List<FarmBuilding>();
    //}
}
//[Serializable]
//public class FarmBuilding
//{
//    public int adsaf;
//    public int adaf;
//}
//[Serializable]
//public class DefenderBuilding
//{
//    public int damage;
//    public int armor;
//    public int speedATK;
//    public int radiusATK;
//}

