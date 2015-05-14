using UnityEngine;
using System.Collections;

public class PlayerBattle : CharacterBattle {

	GameObject target;

	public override void StartBattle(){
		myState = GetComponent<PlayerState>();

		target = GetComponent<PlayerAI>().GetCurrentTarget();

		myParams = GetComponent<PlayerAbility>().GetParams();
		enemyParams = target.GetComponent<MonsterAbility>().GetParams();

		StartCoroutine("BattleBegins");
	}

	public override void DoBattle(){
		SendMessage("ChangeAni", CharacterAni.ATTACK);

		SuccessRoll();
	}

	protected void SuccessRoll(){
		int myAttack = myParams.attack;
		print (myAttack);
		enemyParams.curHP -= myAttack;
	}
}
