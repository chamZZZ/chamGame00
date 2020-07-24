using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : SingletonMonoBehaviour<CameraManager>
{
	[SerializeField]
	private GameObject targetObject = default;

	[SerializeField]
	private Vector3 offsetPos = default;

    // Update is called once per frame
    void Update()
	{
		if( targetObject != null)
		{
			transform.position = targetObject.transform.position + offsetPos;
		}
	}

	public void SetCameraTarget(GameObject obj)
	{
		targetObject = obj;
	}

	public void SetOffsetCamera(Vector3 offset)
	{
		offsetPos = offset;
	}
}
