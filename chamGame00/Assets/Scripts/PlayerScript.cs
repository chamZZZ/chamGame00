using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	[SerializeField]
	private int m_armyNo;
	public int armyNo
	{
		get { return m_armyNo; }
		set { m_armyNo = value; }
	}

	[SerializeField]
	private int m_partyNo;
	public int partyNo
	{
		get { return m_partyNo; }
		set { m_partyNo = value; }
	}

	[SerializeField]
	private int m_fighterNo;
	public int fighterNo
	{
		get { return m_fighterNo; }
		set { m_fighterNo = value; }
	}

	[System.Serializable]
	public class PlayerParam
	{
		public int body;
		public int element;
		public int weapon;
		public int speed;
		public int power;
		public int defence;
		public int bild;
		public int heling;
	}
	public PlayerParam param;

	[SerializeField]
	private GameObject m_model = default;

	[SerializeField]
	private int m_teamOffset;
	public int teamOffset
	{
		get { return m_teamOffset; }
		set { m_teamOffset = value; }
	}

	[SerializeField]
	private float m_speed = default;
	public float speed
	{
		get { return m_speed; }
		set { m_speed = value; }
	}

	//
	public enum MOVE_ROUTINE
	{
		WAIT,
		MOVE,
		ATTACK
	}
	private MOVE_ROUTINE moveRoutine = 0;
	private Vector3 targetPosition;
	private float moveTimer;



	// Start is called before the first frame update
	void Start()
	{
		param = new PlayerParam();
		param = PlayerManager.Instance.GetPlayerParam(armyNo);
//		PlayerManager.Instance.SetPlayerParam(param,armyNo);
		// Model Initialize
		modelInitialize();

		playerInitialize();
	}

	// Update is called once per frame
	void Update()
	{
		switch (moveRoutine)
		{
			case MOVE_ROUTINE.WAIT:
				moveWait();
				break;
			case MOVE_ROUTINE.MOVE:
				moveMove();
				break;
			case MOVE_ROUTINE.ATTACK:
				moveAttack();
				break;
		}

	}

	private void playerInitialize()
	{
		moveRoutine = MOVE_ROUTINE.WAIT;
	}

	private void moveWait()
	{
		moveTimer -= Time.deltaTime;
		if( moveTimer < 0f)
		{
			targetPosition.x = Random.Range(-50f, 50f);
			targetPosition.z = Random.Range(-50f, 50f);
			setMoveMove(targetPosition);
		}

	}

	private void moveMove()
	{
		Vector3 moveVelocity = targetPosition - transform.position;
		if(moveVelocity.magnitude < 1f)
		{
			setMoveWait();
		}
		else
		{
			moveVelocity = moveVelocity.normalized * speed * Time.deltaTime;
			Vector3 pos = transform.position + moveVelocity;
			transform.position = pos;
		}
	}

	private void moveAttack()
	{

	}


	public void setMoveWait()
	{
		moveRoutine = MOVE_ROUTINE.WAIT;
		moveTimer = 3f;
	}

	public void setMoveMove(Vector3 targetPos)
	{
		moveRoutine = MOVE_ROUTINE.MOVE;

		targetPosition = targetPos;
	}

	public void setMoveAttack()
	{
		moveRoutine = MOVE_ROUTINE.ATTACK;

	}

	private void modelInitialize()
	{
		m_model = ModelManager.Instance.GetModelObject(param.body);
		m_model.transform.SetParent(transform);
		m_model.transform.localPosition = new Vector3(0f, 1f, 0f);

		MeshRenderer mesh = m_model.GetComponent<MeshRenderer>();

		switch(param.element)
		{
			case 0:
				mesh.material.color = new Color(1f, 0f, 0f, 1f);
				break;
			case 1:
				mesh.material.color = new Color(0f, 0f, 1f, 1f);
				break;
			case 2:
				mesh.material.color = new Color(0f, 1f, 0f, 1f);
				break;
		}
	}
}
