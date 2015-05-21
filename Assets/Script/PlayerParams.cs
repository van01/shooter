using UnityEngine;
using System.Collections;

public class PlayerParams : CharacterParams {

	public int level {get; set;}
	public decimal money {get; set;}
	public int cristal {get; set;}
	public decimal honor {get; set;}

	public PlayerParams(){
		this.Name = "unnamed player";
		this.id = 0;
		this.level = 1;
		this.attack = 5;
		this.maxHP = 100;
		this.curHP = this.maxHP;
		this.money = 0;
		this.cristal = 0;
		this.honor = 0;
	}
}
