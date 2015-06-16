using UnityEngine;
using System.Collections;

public class PlayerParams : CharacterParams {

	public decimal money {get; set;}
	public int cristalPer {get; set;}
	public float cristalDamage {get; set;}
	public float bossAddDamage {get; set;}
	public decimal honor {get; set;}

	public PlayerParams(){
		this.Name = "unnamed player";
		this.id = 0;
		this.level = 1;
		this.attack = 567891000000000000000000000m;
		this.maxHP = 100;
		this.curHP = this.maxHP;
		this.money = 0;
		this.cristalPer = 20;
		this.cristalDamage = 2.0f;
		this.bossAddDamage = 2.0f;
		this.honor = 0;
	}
}
