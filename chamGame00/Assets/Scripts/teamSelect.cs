using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teamSelect : MonoBehaviour
{
	[SerializeField]
	private int currentTeam = 0;

	[SerializeField]
	private UIManager uIManager = default;

	private void Awake()
	{
		transform.localPosition = new Vector3(0f, -448f, 0f);
	}

	public void open()
	{
	}

	public void close()
	{
	}

	public void onClickTeamSelect(int no)
	{
		currentTeam = no;

		uIManager.UIControl(2);
	}
}
