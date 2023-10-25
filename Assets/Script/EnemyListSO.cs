using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "SO/EnemyListSO")]
public class EnemyListSO : ScriptableObject
{
    public List<EnemyTypeSO> enemyList;
}
