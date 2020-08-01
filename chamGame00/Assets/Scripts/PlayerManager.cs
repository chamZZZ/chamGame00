using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : SingletonMonoBehaviour<PlayerManager>
{
	[SerializeField]
	private List<PlayerScript> players = default;

	[SerializeField]
	private GameObject playerObject = default;

	[SerializeField]
	private int currentPlayerNo = 0;


	// Start is called before the first frame update
	void Start()
	{
		SetPlayerInit();
		SetCurrentPlayer(0);

	}

	// Update is called once per frame
	void Update()
	{

	}

	private void SetPlayerInit()
	{
		for(int i = 0; i < PlayerContext.PLAYER_NUM; i++)
		{
			GameObject obj = Instantiate(playerObject);
			obj.transform.SetParent(transform);

			PlayerScript plScr = obj.GetComponent<PlayerScript>();

			Vector3 pos = new Vector3();
			pos.x = Random.Range(-50f, 50f);
			pos.z = Random.Range(-50f, 50f);
			pos.y = 0f;
			plScr.transform.position = pos;

			players.Add(plScr);
		}
	}

	public void SetPlayerParam(PlayerScript.PlayerParam param)
	{
		param.body = Random.Range(0, 3);
		param.element = Random.Range(0, 3);
		param.weapon = Random.Range(0, 3);

	}

	public void SetCurrentPlayer(int No)
	{
		currentPlayerNo = No;
		CameraManager.Instance.SetCameraTarget(players[No].transform.gameObject);
	}
}
