using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovementController : MonoBehaviour {

	public GameObject boat; 
	public float speedBoat;

	public Transform headPoint;
	public Transform endPoint;


	public LayerMask whatIsCreature;
	public Animation boatController;
	[SerializeField]
	private bool isTurnOnBoat;
	private bool moveBoat;

	[SerializeField]
	private float radiusCheck;


	private bool isMoveToRight;
	// Use this for initialization
	void Start () {
		isTurnOnBoat = false;
		moveBoat = false;

		isMoveToRight = true;
	}
	
	// Update is called once per frame
	void Update () {
		TurnOnBoat();

		if(isTurnOnBoat)
		{
			boatController.Play();
			moveBoat = true;
			isTurnOnBoat = false;
		}

		if(moveBoat)
		{
			MoveBoat();
		}
	}

	private void TurnOnBoat()
	{
		if(Physics2D.OverlapCircle(transform.position, radiusCheck, whatIsCreature) && GameManager.select)
		{
			isTurnOnBoat = true;
		}
	}

	private void MoveBoat()
	{
		//Move to the right
		if(isMoveToRight)
		{
			if(boat.transform.position.x < endPoint.position.x)
			{
				boat.transform.position = Vector2.MoveTowards(boat.transform.position, endPoint.position, speedBoat * Time.deltaTime);
			}
			else
			{
				isMoveToRight = false;
				moveBoat = false;
			}
		}
		//Move to the left
		else
		{
			if(boat.transform.position.x > headPoint.transform.position.x)
			{
				boat.transform.position = Vector2.MoveTowards(boat.transform.position, headPoint.position, speedBoat * Time.deltaTime);
			}
			else
			{
				isMoveToRight = true;
				moveBoat = false;
			}
		}
	}
}
