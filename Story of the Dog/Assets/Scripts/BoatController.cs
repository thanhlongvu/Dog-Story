using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour {

	[SerializeField]
	private Transform topPoint;
	
	[SerializeField]
	private Transform bottomPoint;
	public float speed;

	private bool isMoveTop = true;
	void Update () {
		if(isMoveTop)
			MoveToTopPoint();
		else
			MoveToBottomPoint();
	}

	private void MoveToTopPoint()
	{

		if(transform.position.y < topPoint.position.y)
		{
			transform.Translate(0, speed * Time.deltaTime, 0);
		}
		else
		{
			isMoveTop = false;
		}
	}

	private void MoveToBottomPoint()
	{

		if(transform.position.y > bottomPoint.position.y)
		{
			transform.Translate(0, -speed * Time.deltaTime, 0);
		}
		else
		{
			isMoveTop = true;
		}
	}




	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.transform.tag == "Player")
		{
			other.transform.parent = transform;
			
		}
	}

	void OnCollisionExit2D(Collision2D other)
	{
		if(other.transform.tag == "Player")
		{
			other.transform.parent = null;
			
		}
	}
}
