using System;
using UnityEngine;

[Serializable]
public class Spawn
{
	public float delay;

	public GameObject enemyPrefab;

	public int count;

	public float interval;

	public Transform spawnLine;

	public int goldCoins;

	private int[] goldCoinsPerEnemy;

	private float waitBeforeNextSpawn;

	private int spawnedUnits;

	private bool finished;

	private bool tauntTheTiger;

	private bool tauntTheTurtle;

	private bool tauntTheFalcon;

	private bool tauntTheRat;

	//private Hp hpTemp;

	public int SpawnedUnits => spawnedUnits;

	public bool Finished => finished;

	public void Reset(bool _resetGold = true)
	{
		//tauntTheTiger = PerkManager.IsEquipped(PerkManager.instance.tigerGodPerk);
		//tauntTheTurtle = PerkManager.IsEquipped(PerkManager.instance.turtleGodPerk);
		//tauntTheFalcon = PerkManager.IsEquipped(PerkManager.instance.falconGodPerk);
		//tauntTheRat = PerkManager.IsEquipped(PerkManager.instance.ratGodPerk);
		waitBeforeNextSpawn = delay;
		spawnedUnits = 0;
		finished = false;
		goldCoinsPerEnemy = new int[count];
		int num = goldCoins;
		if (tauntTheRat)
		{
			//num = Mathf.FloorToInt((float)num * PerkManager.instance.ratGod_GoldModifyer);
		}
		for (int i = 0; i < num; i++)
		{
			goldCoinsPerEnemy[UnityEngine.Random.Range(0, goldCoinsPerEnemy.Length)] = 0;
		}
		if (_resetGold)
		{
			for (int j = 0; j < num; j++)
			{
				goldCoinsPerEnemy[UnityEngine.Random.Range(0, goldCoinsPerEnemy.Length)]++;
			}
		}
	}

	public void Update()
	{
		//if (finished)
		//{
		//	return;
		//}
		//waitBeforeNextSpawn -= Time.deltaTime;
		//if (waitBeforeNextSpawn > 0f)
		//{
		//	return;
		//}
		//waitBeforeNextSpawn = interval;
		//Vector3 randomPointOnSpawnLine = GetRandomPointOnSpawnLine();
		//GameObject gameObject;
		//if (spawnLine == enemyPrefab.transform)
		//{
		//	gameObject = enemyPrefab;
		//	gameObject.SetActive(value: true);
		//}
		//else
		//{
		//gameObject = UnityEngine.Object.Instantiate(enemyPrefab, randomPointOnSpawnLine, Quaternion.identity);
		//EnemySpawnManager instance = EnemySpawnManager.instance;
		//if ((bool)instance.weaponOnSpawn)
		//{
		//	instance.weaponOnSpawn.Attack(randomPointOnSpawnLine + Vector3.up * instance.weaponAttackHeight, null, Vector3.forward, gameObject.GetComponent<TaggedObject>());
		//}
		//}
		//if (goldCoinsPerEnemy.Length > spawnedUnits)
		//{
		//	gameObject.GetComponentInChildren<Hp>().coinCount = goldCoinsPerEnemy[spawnedUnits];
		//}
		//if (tauntTheTurtle)
		//{
		//	hpTemp = gameObject.GetComponentInChildren<Hp>();
		//	hpTemp.maxHp *= PerkManager.instance.tauntTheTurtle_hpMultiplyer;
		//	hpTemp.Heal(float.MaxValue);
		//}
		//if (tauntTheTiger)
		//{
		//	AutoAttack[] componentsInChildren = gameObject.GetComponentsInChildren<AutoAttack>();
		//	for (int i = 0; i < componentsInChildren.Length; i++)
		//	{
		//		componentsInChildren[i].DamageMultiplyer *= PerkManager.instance.tauntTheTiger_damageMultiplyer;
		//	}
		//	Hp[] componentsInChildren2 = gameObject.GetComponentsInChildren<Hp>();
		//	for (int i = 0; i < componentsInChildren2.Length; i++)
		//	{
		//		componentsInChildren2[i].DamageMultiplyer *= PerkManager.instance.tauntTheTiger_damageMultiplyer;
		//	}
		//}
		//if (tauntTheFalcon)
		//{
		//	PathfindMovementEnemy[] componentsInChildren3 = gameObject.GetComponentsInChildren<PathfindMovementEnemy>();
		//	foreach (PathfindMovementEnemy obj in componentsInChildren3)
		//	{
		//		obj.movementSpeed *= PerkManager.instance.tauntTheFalcon_speedMultiplyer;
		//		obj.agroTimeWhenAttackedByPlayer *= PerkManager.instance.tauntTheFalcon_chasePlayerTimeMultiplyer;
		//	}
		//}
		//spawnedUnits++;
		//if (spawnedUnits >= count)
		//{
		//	finished = true;
		//}
		//}

		//public Vector3 GetRandomPointOnSpawnLine()
		//{
		//	float num = GetTotalSpawnLineLength() * UnityEngine.Random.value;
		//	float num2 = 0f;
		//	for (int i = 0; i < spawnLine.childCount - 1; i++)
		//	{
		//		//float magnitude = (spawnLine.GetChild(i).position - spawnLine.GetChild(i + 1).position).magnitude;
		//		//if (magnitude != 0f)
		//		//{
		//		//	if (magnitude + num2 >= num)
		//		//	{
		//		//		num -= num2;
		//		//		float t = num / magnitude;
		//		//		Vector3 position = Vector3.Lerp(spawnLine.GetChild(i).position, spawnLine.GetChild(i + 1).position, t);
		//		//		return AstarPath.active.GetNearest(position).position;
		//		//	}
		//		//	num2 += magnitude;
		//		//}
		//	}
		//	//if (spawnLine.childCount > 0)
		//	//{
		//	//	return AstarPath.active.GetNearest(spawnLine.GetChild(0).position).position;
		//	//}
		//	//return AstarPath.active.GetNearest(spawnLine.position).position;
		//}

		//public float GetTotalSpawnLineLength()
		//{
		//	float num = 0f;
		//	for (int i = 0; i < spawnLine.childCount - 1; i++)
		//	{
		//		num += (spawnLine.GetChild(i).position - spawnLine.GetChild(i + 1).position).magnitude;
		//	}
		//	return num;
		//}
	}
}
