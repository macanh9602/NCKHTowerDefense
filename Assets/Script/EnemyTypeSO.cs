using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "SO/EnemyTypeSO")]
public class EnemyTypeSO : ScriptableObject
{
    public string name;
    public Transform pref;
    public float health;
    public float damage;
    public Transform target;
}
