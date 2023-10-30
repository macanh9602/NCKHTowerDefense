using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Wave
{
	[TextArea]
	public string warningText;

	public List<Spawn> spawns = new List<Spawn>();

	public void Reset(bool _resetGold = true)
	{
		for (int i = 0; i < spawns.Count; i++)
		{
			spawns[i].Reset(_resetGold);
		}
	}

	public void Update()
	{
		for (int i = 0; i < spawns.Count; i++)
		{
			spawns[i].Update();
		}
	}

	public bool HasFinished() 
	{
		int num = 0;
		for (int i = 0; i < spawns.Count; i++)
		{
			if (spawns[i].Finished)
			{
				num++;
			}
		}
		if (num >= spawns.Count)
		{
			return true;
		}
		return false;
	}
}
