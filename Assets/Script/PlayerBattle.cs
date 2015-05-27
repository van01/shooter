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
		int criPer;
		decimal myAttack;

		// 상대편이 보스일 경우 bossAddDamage
		if (enemyParams.monsterType == "boss")
			myAttack = myParams.attack * (decimal)myParams.bossAddDamage;
		else
			myAttack = myParams.attack;

		// 크리티컬 확률 계산 및 크리티컬 데미지 계산
		criPer = Random.Range(0,101);
		if(criPer <= myParams.cristalPer){
			myAttack = myAttack * (decimal)myParams.cristalDamage;
			tmpGameController.SendMessage("MonsterHitCriticalDamage", myAttack);
		}else{
			tmpGameController.SendMessage("MonsterHitDamage", myAttack);
		}

		//적 HP 감소
		enemyParams.curHP -= myAttack;

		float curHPPer = (float)enemyParams.curHP/(float)enemyParams.maxHP;

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
