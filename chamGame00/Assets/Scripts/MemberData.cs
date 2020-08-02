using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Create MemberData")]
public class MemberData : ScriptableObject
{
	public List<PlayerScript.PlayerParam> armyData = new List<PlayerScript.PlayerParam>();

	private void Reset()
	{
		for (int i = 0; i < 100 ; i++)
		{
			PlayerScript.PlayerParam param = new PlayerScript.PlayerParam();
			param.body = Random.Range(0, 3);
			param.element = Random.Range(0, 3);
			param.weapon = Random.Range(0, 3);

			armyData.Add(param);
		}

	}
}
