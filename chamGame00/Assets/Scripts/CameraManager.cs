using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : SingletonMonoBehaviour<CameraManager>
{
	[SerializeField]
	private GameObject targetObject = default;

	[SerializeField]
	private Vector3 offsetPos = default;

	[SerializeField]
	private float distance = 15.0f; // distance from following object

	[SerializeField]
	private float polarAngle = 45.0f; // angle with y-axis

	[SerializeField]
	private float azimuthalAngle = 45.0f; // angle with x-axis


	// Update is called once per frame
	void Update()
	{
		if( targetObject != null)
		{
			var lookAtPos = targetObject.transform.position + offsetPos;
			updatePosition(lookAtPos);
			transform.LookAt(lookAtPos);
		}
	}

	void updatePosition(Vector3 lookAtPos)
	{
		var da = azimuthalAngle * Mathf.Deg2Rad;
		var dp = polarAngle * Mathf.Deg2Rad;
		transform.position = new Vector3(
			lookAtPos.x + distance * Mathf.Sin(dp) * Mathf.Cos(da),
			lookAtPos.y + distance * Mathf.Cos(dp),
			lookAtPos.z + distance * Mathf.Sin(dp) * Mathf.Sin(da));
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
