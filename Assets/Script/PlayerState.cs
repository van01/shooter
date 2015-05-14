using UnityEngine;
using System.Collections;

public class PlayerState : CharacterState {

	void Start(){
		CharacterStateControll("Idle");
	}

	public override void IdleAction(){
		base.IdleAction();
	}

	public override void AttackAction(){
		base.AttackAction();
	}

	public override void CharacterStateControll(string i){
		base.CharacterStateControll(i);
	}
}
