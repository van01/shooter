using UnityEngine;
using System.Collections;

public class PlayerBattle : CharacterBattle {
	
	GameObject target;
	GameObject tmpGameController;

	void Start(){
		tmpGameController = GameObject.Find("GameController");
	}

	public override void StartBattle(){
		myState = GetComponent<PlayerState>();

		SendMessage("SearchEnemy");
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
		enemyParams.curHP -= myAttack;
		CheckEnemyCurHP();
	}

	protected void CheckEnemyCurHP(){
		if (enemyParams.curHP > 0)
			return;
		else
			tmpGameController.SendMessage("GameStateControll", "BattleEnd");
	}
}
