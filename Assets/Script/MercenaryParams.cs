using UnityEngine;
using System.Collections;

public class MercenaryParams : CharacterParams {

	public float attackDelay {get; set;}
	public string attackRangeType {get; set;}

	public MercenaryParams(){
		this.Name = "unnamed Mercenary";
		this.id = 0;
		this.level = 1;
		this.attack = 567891000000000000000000000m;
		this.maxHP = 100;
		this.curHP = this.maxHP;
		this.attackDelay = 1.0f;
		this.attackRangeType = "short";
	}
}
