using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orderSelect : MonoBehaviour
{
	[SerializeField]
	private int currentOrder = 0;

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

	public void onClickOrderSelect(int no)
	{
		currentOrder = no;

		uIManager.UIControl(1);
	}

}
