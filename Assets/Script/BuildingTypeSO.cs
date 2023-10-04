using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/BuildingTypeSO")] 
public class BuildingTypeSO : ScriptableObject
{
    public string nameBuilding;
    public Transform[] pref;
    public int level;
    public int costToBuildOrUpgrate;
    public int health;
    
}
public class DefenderBuilding
{
    public int damage;
    public int armor;
    public int speedATK;
    public int radiusATK;
}
