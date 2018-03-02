using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour {

	private MovementController movePlayer;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		movePlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementController>();
	}

	public void PressLeftButton()
	{
		movePlayer.moveLeft = true;
		movePlayer.moveRight = false;
	}
	public void ReleaseLeftButton()
	{
		movePlayer.moveLeft = false;
	}

	public void PressRightButton()
	{
		movePlayer.moveRight = true;
		movePlayer.moveLeft = false;
	}
	public void ReleaseRightButton()
	{
		movePlayer.moveRight = false;
	}

	public void PressJumpButton()
	{
		if(movePlayer.onGround)
		{
			movePlayer.isJump = true;
			movePlayer.isFall = false;
		}
		else
		{
			movePlayer.isJump = false;
			movePlayer.isFall = true;
		}
	}
	public void ReleaseJumpButton()
	{
		
		movePlayer.isJump = false;
		movePlayer.isFall = false;
		
	}

	public void PressSelectButton()
	{
		GameManager.select = true;
	}

	public void ReleaseSelectButton()
	{
		GameManager.select = false;
	}
}
