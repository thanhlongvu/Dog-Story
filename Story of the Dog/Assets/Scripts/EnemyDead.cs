using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDead : MonoBehaviour {

	// Use this for initialization
	public GameObject coinObject;

	public GameObject deadEffect;

	[SerializeField]
	private float force;

	[SerializeField]
	private Transform[] points;

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
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.transform.tag == "Player")
		{
			Dead();
		}
	}
}
