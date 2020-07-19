using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	[SerializeField]
	private teamSelect teamSelect = default;

	[SerializeField]
	private orderSelect orderSelect = default;


	public void UIControl(int no)
	{
		switch(no)
		{
			case 1:
				teamSelect.close();
				orderSelect.open();
				teamSelect.gameObject.SetActive(true);
				orderSelect.gameObject.SetActive(false);
				break;
			case 2:
				teamSelect.open();
				orderSelect.close();
				teamSelect.gameObject.SetActive(false);
				orderSelect.gameObject.SetActive(true);
				break;
		}

	}
}
