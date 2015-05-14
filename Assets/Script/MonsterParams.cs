using UnityEngine;
using System.Collections;

public class MonsterParams : CharacterParams {

	public int moneyBonus {get; set;}

	public MonsterParams(){
		this.Name = "unnamed Monster";
		this.id = 0;
		this.attack = 3;
		this.maxHP = 50;
		this.curHP = this.maxHP;
		this.moneyBonus = 10;
	}
}
