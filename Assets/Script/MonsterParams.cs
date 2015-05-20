using UnityEngine;
using System.Collections;

public class MonsterParams : CharacterParams {

	public int moneyBonus {get; set;}
	public string monsterType {get; set;}

	public MonsterParams(){
		this.Name = "unnamed Monster";
		this.id = 0;
		this.monsterType = "none";
		this.attack = 3;
		this.maxHP = 50;
		this.curHP = this.maxHP;
		this.moneyBonus = 10;
	}
}
