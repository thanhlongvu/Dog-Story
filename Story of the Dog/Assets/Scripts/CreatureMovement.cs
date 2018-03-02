using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureMovement : MonoBehaviour {

	[SerializeField]
	private Transform headPoint;
	
	[SerializeField]
	private Transform endPoint;

	public float speed;

	private bool flip;
	void Start () {
		flip = false;
	}
	
	void Update () {
		if(!flip)
		{
			MoveToHeadPoint();
		}
		else
		{
			MoveToEndPoint();
		}
	}

	private void MoveToHeadPoint()
	{
		GetComponent<SpriteRenderer>().flipX = false;
		if(transform.position.x > headPoint.position.x)
		{
			transform.Translate(-speed * Time.deltaTime, 0, 0);
		}
		else
		{
			flip = true;
		}
	}

	private void MoveToEndPoint()
	{
		GetComponent<SpriteRenderer>().flipX = true;
		if(transform.position.x < endPoint.position.x)
		{
			transform.Translate(speed * Time.deltaTime, 0, 0);
		}
		else
		{
			flip = false;
		}
	}
}
