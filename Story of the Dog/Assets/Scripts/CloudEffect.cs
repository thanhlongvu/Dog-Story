using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudEffect : MonoBehaviour {

	// Use this for initialization
	public float speed; 
	public Transform point;

	public Transform headPoint;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Move horizontal
		transform.Translate(speed * Time.deltaTime, 0, 0);

		if(transform.position.x >= point.position.x)
		{
			transform.position = new Vector2(headPoint.position.x, transform.position.y);
		}
	}
}
