using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailManager : MonoBehaviour {

	// Use this for initialization
	public float timeCooldownAttack;

	private float timeAttacked;

	private bool isAttack;


	public GameObject coinObject;

	public GameObject deadEffect;

	[SerializeField]
	private float force;

	[SerializeField]
	private Transform[] points;

	void Start()
	{
		isAttack = false;
		timeAttacked = 0;
	}

	void Update()
	{
		if(isAttack)
		{
			Attack();
			isAttack = false;
		}
			
	}

	public void Dead()
	{
		GameObject effect = Instantiate(deadEffect, transform.position, transform.rotation);
		Destroy(effect, 0.35f);

		BornCoin();

		Destroy(transform.parent.gameObject);
	}

	private void BornCoin()
	{
		GameObject coin = Instantiate(coinObject, points[0].position, points[0].rotation);
		coin.GetComponent<Rigidbody2D>().AddForce(Vector2.right * force);

		Destroy(coin, 5f);
	}


	private bool CooldownAttack()
	{	
		if(Time.time >= timeAttacked + timeCooldownAttack)
		{
			timeAttacked = Time.time;
			return true;
		}
		else
		{
			return false;
		}
	}

	private void Attack()
	{
		if(CooldownAttack())
		{
			
			Debug.Log("The player is attacked!");
		}
			
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.transform.tag == "Player" && other.GetComponent<MovementController>().isAttack == true)
		{
			Dead();
		}
		else if(other.transform.tag == "Player")
		{
			//The player is attacked
			isAttack = true;

			//Cooldown of the snail
			
		}
	}
}
