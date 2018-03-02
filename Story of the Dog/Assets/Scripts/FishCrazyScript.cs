using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCrazyScript : MonoBehaviour {

	private GameObject player;

	public Transform head;
	public Transform end;

	public Vector2 rightAttackVector;
	public Vector2 leftAttackVector;

	[SerializeField]
	private float speed;

	[SerializeField]
	private float rangeAttack;

	[SerializeField]
	private bool isMoveRight;

	[SerializeField]
	private bool isPatrol;
	[SerializeField]
	private bool isAttack;

	private Rigidbody2D rb2d;

	private float yBegin;

	[Header("Change Sprites")]
	public Sprite patrolFishSprite;
	public Sprite attackFishSprite;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		rb2d = GetComponent<Rigidbody2D>();

		isMoveRight = true;

		isPatrol = true;
		isAttack = false;

		yBegin = transform.position.y;
	}
	
	
	void Update () {
		SetStateCurrent();

		if(isPatrol)
			Patrol();

		if(isAttack)
			Attack();

		FishFall();
	}



	//Patrol
	private void Patrol()
	{
		if(isMoveRight)
		{
			GetComponent<SpriteRenderer>().flipX = false;
			if(transform.position.x < head.position.x)
			{
				transform.Translate(speed * Time.deltaTime, 0, 0);
			}
			else
			{
				isMoveRight = false;

			}
		}
		else
		{
			GetComponent<SpriteRenderer>().flipX = true;
			if(transform.position.x > end.position.x)
			{
				transform.Translate(-speed * Time.deltaTime, 0, 0);
			}
			else
			{
				isMoveRight = true;
			}
		}
	}

	// //Chase
	// private void Chase()
	// {

	// }

	//Attack
	private void Attack()
	{
		GetComponent<SpriteRenderer>().sprite = attackFishSprite;
		
		if(isMoveRight)
		{
			rb2d.velocity = rightAttackVector;
			rb2d.gravityScale = 1f;
		}
		else
		{

			rb2d.velocity = leftAttackVector;
			rb2d.gravityScale = 1f;
		}
	}

	private void SetStateCurrent()
	{
		float dis = Vector2.Distance(player.transform.position, transform.position);

		if(dis <= rangeAttack && Meet())
		{
			isAttack = true;
			isPatrol = false;
		}
		else
		{
			isAttack = false;
			isPatrol = true;
		}
	}

	private void FishFall()
	{
		if(transform.position.y < yBegin)
		{
			GetComponent<SpriteRenderer>().sprite = patrolFishSprite;

			rb2d.gravityScale = 0;
			rb2d.velocity = Vector2.zero;
			transform.position = new Vector2(transform.position.x, yBegin);
		}

		if(transform.position.x > head.transform.position.x || transform.position.x < end.transform.position.x)
		{
			rb2d.velocity = Vector2.zero;
		}
	}

	private bool Meet()
	{
		if(player.transform.position.x < head.transform.position.x && player.transform.position.x > end.transform.position.x
						 && transform.position.y == yBegin)
		{
			if(isMoveRight && player.transform.position.x > transform.position.x)
				return true;
			else if(!isMoveRight && player.transform.position.x < transform.position.x)
				return true;
			else
				return false;
		}

		return false;
	}


	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, rangeAttack);
	}
}
