using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelManager : SingletonMonoBehaviour<ModelManager>
{
	[SerializeField]
	private List<GameObject> modelList = default;

	public GameObject GetModelObject(int modelNo)
	{
		GameObject obj = Instantiate(modelList[modelNo]);
		return obj;
	}
}
