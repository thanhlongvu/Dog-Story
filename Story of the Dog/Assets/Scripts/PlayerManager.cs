using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerManager: ScriptableObject{

	public int maxHealth;
	private int healthCurrent {get; set;}
	private int money {get; set;}

	public PlayerManager()
	{
		healthCurrent = maxHealth;
		money = 0;
	}

	

}
