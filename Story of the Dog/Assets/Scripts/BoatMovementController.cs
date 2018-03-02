using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovementController : MonoBehaviour {

	public GameObject boat; 
	public float speedBoat;

	public Transform endPoint;

	public LayerMask whatIsCreature;
	public Animation boatController;
	[SerializeField]
	private bool isTurnOnBoat;
	private bool moveBoat;

	[SerializeField]
	private float radiusCheck;
	// Use this for initialization
	void Start () {
		isTurnOnBoat = false;
		moveBoat = false;
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

		if(moveBoat && boat.transform.position.x < endPoint.position.x)
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
		// boat.transform.Translate(0, speedBoat * Time.deltaTime, 0);
		boat.transform.position = Vector2.MoveTowards(boat.transform.position, endPoint.position, speedBoat * Time.deltaTime);
	}


	
}
