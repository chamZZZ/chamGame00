using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teamScript : MonoBehaviour
{
	[SerializeField]
	private List<PlayerScript> playerList = default;

	[SerializeField]
	private int currentFormation = 0;

	private Vector3[] formationOffset = new Vector3[20];

	// Start is called before the first frame update
	void Start()
	{
		SetFormation(currentFormation);
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void SetFormation(int No)
	{
		switch(No)
		{
			case 0:
				for (int i = 0; i < 20; i++)
				{
					formationOffset[i] = new Vector3(0f, 0f, i * 1.5f);
				}
				break;
			case 1:
				for (int i = 0; i < 20; i++)
				{
					formationOffset[i] = new Vector3(0f, 0f, i * 2f);
				}
				break;
		}
	}

	public void teamPlayerAdd(PlayerScript plScr)
	{
		playerList.Add(plScr);
		plScr.teamOffset = playerList.Count - 1;
	}

	public void teamPlayerRemove(PlayerScript plScr)
	{
		// 兵士削除
		playerList.Remove(plScr);

		// 隊列番号　再設定
		for(int i = 0; i < playerList.Count; i++)
		{
			playerList[i].teamOffset = i;
		}
	}
}
