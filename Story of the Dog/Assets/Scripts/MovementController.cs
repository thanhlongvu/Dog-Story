using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

	[Header("Information")]
	public float speed = 10f;
	
	public float jumpForce = 20f;
	[SerializeField]
	private float fallForce = 10f;

	private float fallForceMax;
	private Animator anim;
	private bool isRight;
	private Rigidbody2D rb2d;

	[Header("Check on Ground")]
	public Transform groundCheck;
	public float radiusCheck;
	public LayerMask whatIsGround;
	public LayerMask whatIsEnemy;


	public bool onGround;

	private float radiusCheckBegin;

	//Input and move
	public bool moveLeft;
	public bool moveRight;
	public bool isJump;
	public bool isFall;

	public PhysicsMaterial2D phyMat2d;

	[Header("Debug")]
	public bool drawGizmos;
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		isRight = true;
		radiusCheckBegin = radiusCheck;

		moveLeft = false;
		moveRight = false;
		isJump = false;
		isFall = false;
		fallForceMax = 3 * fallForce;
	}
	
	// Update is called once per frame
	void Update () {
		MoveAndJump();
		ChangeAnimation();
		//Collider with enemy
		ColliderWithEnemy();

	}

	//Move Horizontal
	private void MoveAndJump()
	{
		//Horizontal
		if(moveLeft || Input.GetKey(KeyCode.A))
		{
			rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);

			//Animation
			if(isRight)
			{
				Flip();
			}

		}
		if(moveRight || Input.GetKey(KeyCode.D))
		{
			rb2d.velocity = new Vector2(speed, rb2d.velocity.y);


			//Animation
			if(!isRight)
			{
				Flip();
			}
		}

		//Vertical
		if((Input.GetKeyDown(KeyCode.W) || isJump) && onGround)
		{
			rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
		}

		//Ignore check LayerMask to exterminat enemy
		if((Input.GetKeyDown(KeyCode.W) || isFall) && !onGround )
		{
			radiusCheck = 0;
			//Increase fall speed
			fallForce = fallForceMax;
		}

		//PC
		// if(Input.GetKeyUp(KeyCode.W) && fallForce == fallForceMax)
		// {
		// 	radiusCheck = radiusCheckBegin;
		// 	fallForce = fallForceMax / 3;
		// }
		
		//Mobile
		if(!isFall && fallForce == fallForceMax)
		{
			radiusCheck = radiusCheckBegin;
			fallForce = fallForceMax / 3;
		}
	}

	void FixedUpdate()
	{
		onGround = Physics2D.OverlapCircle(groundCheck.position, radiusCheck, whatIsGround);
		AddForceFall();

	}

	private void Flip()
	{
		isRight = !isRight;
		GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
	}

	private void ChangeAnimation()
	{
		anim.SetFloat("speed", Mathf.Abs(rb2d.velocity.x));
		anim.SetFloat("Yvelocity", rb2d.velocity.y);

		//Jumping
		if(rb2d.velocity.y >= 0.1f)
		{
			anim.SetBool("jump", true);
		}
		else
		{
			anim.SetBool("jump", false);
		}

	}


	//Ignore collider wall around
	private void AddForceFall()
	{
		if(rb2d.velocity.y < 0f)
		{
			rb2d.AddForce(new Vector2(0, -fallForce), ForceMode2D.Impulse);
		}
	}


	//With Enemies
	//Add velocity for y axis
	private void ColliderWithEnemy()
	{
		if(Physics2D.OverlapCircle(groundCheck.position, radiusCheck, whatIsEnemy))
		{
			rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
		}
	}

	


	//GET
	public Vector2 GetVelocity()
	{
		return rb2d.velocity;
	}






	void OnDrawGizmos()
	{
		if(drawGizmos)
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(groundCheck.position, radiusCheck);
		}
		
	}

}
