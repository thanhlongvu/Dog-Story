using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerManager: ScriptableObject{

	public int maxHealth = 5;
	public int healthCurrent {get; set;}
	public int money {get; set;}

	public PlayerManager()
	{
		healthCurrent = maxHealth;
		money = 0;
	}
}
