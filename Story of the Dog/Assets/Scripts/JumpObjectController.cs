using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpObjectController : MonoBehaviour {

	public Transform point;
	public LayerMask layer;
	public float hor;
	public float ver;


	public float force;

	private Animator anim;

	void Start () {
		anim = GetComponent<Animator>();
	}
	
	void FixedUpdate () {
		CheckJump();

	}
	private void CheckJump()
	{
		if(Physics2D.OverlapBox(point.position, new Vector2(hor, ver), 0, layer))
		{
			GameObject player = GameObject.FindGameObjectWithTag("Player") as GameObject;
			player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force, ForceMode2D.Impulse);
			anim.SetBool("isJumping", true);
		}
		else{
			anim.SetBool("isJumping", false);
		}
	}


	void OnDrawGizmos()
	{
		Gizmos.color = Color.green;

		Gizmos.DrawWireCube(point.position, new Vector3(hor, ver, 0));		
	}
}
