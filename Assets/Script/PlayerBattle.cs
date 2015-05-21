using UnityEngine;
using System.Collections;

public class PlayerBattle : CharacterBattle {
	
	public GameObject target;
	private GameObject tmpGameController;

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
		decimal myAttack = myParams.attack;
		enemyParams.curHP -= myAttack;
		float curHPPer = (float)enemyParams.curHP/(float)enemyParams.maxHP;

		tmpGameController.SendMessage("MonsterHitDamage", myAttack);

		tmpGameController.SendMessage("UpdateHealthBar", curHPPer);

		CheckEnemyCurHP();
	}

	protected void CheckEnemyCurHP(){
		if (enemyParams.curHP > 0)
			return;
		else
			tmpGameController.SendMessage("GameStateControll", "BattleEnd");
	}
}
