using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	[SerializeField]
	private PlayerParam m_param;
	public PlayerParam param
	{
		get { return m_param; }
		set { m_param = value; }
	}

	[SerializeField]
	private GameObject m_model = default;
	[SerializeField]
	private int m_teamNo;
	public int teamNo
	{
		get { return m_teamNo; }
		set { m_teamNo = value; }
	}

	[SerializeField]
	private int m_teamOffset;
	public int teamOffset
	{
		get { return m_teamOffset; }
		set { m_teamOffset = value; }
	}

	[SerializeField]
	private int m_playerNo;
	public int playerNo
	{
		get { return m_playerNo; }
		set { m_playerNo = value; }
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
		modelInitialize(teamNo);

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

	private void modelInitialize(int teamNo)
	{
		if (m_model == null) return;

		MeshRenderer mesh = m_model.GetComponent<MeshRenderer>();

		if(teamNo ==0 )
		{
			mesh.material.color = new Color(1f, 0f, 0f, 1f);
		}
		else
		{
			mesh.material.color = new Color(0f, 0f, 1f, 1f);
		}
	}
}
