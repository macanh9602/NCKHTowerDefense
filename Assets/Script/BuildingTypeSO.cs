using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/BuildingTypeSO")] 
public class BuildingTypeSO : ScriptableObject
{
    public string nameBuilding;
    public Transform[] pref;
    public int level;
}
