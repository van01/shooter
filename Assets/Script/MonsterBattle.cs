using UnityEngine;
using System.Collections;

public class MonsterBattle : CharacterBattle {

	public GameObject coinPrefab;
	protected int coinValue;

	private GameObject presentCoin;

	private GameObject tmpGameController;


	void Start(){
		tmpGameController = GameObject.Find("GameController");
	}

	public override void StartBattle(){
		enemyParams = GetComponent<MonsterAbility>().GetParams();
	}

	public void MonsterDie(){
		int nCoinCount = 0;
		if (enemyParams.monsterType == "boss"){
			nCoinCount = Random.Range(10,21);
			for(int i=0;i<=nCoinCount;i++)
			{
				coinValue = enemyParams.moneyBonus / nCoinCount;
				presentCoin = Instantiate(coinPrefab,tmpGameController.transform.position,tmpGameController.transform.rotation) as GameObject;
				presentCoin.SendMessage ("CoinValueSetting", coinValue);
			}
		} else{
			nCoinCount = Random.Range(3,6);
			for(int i=0;i<=nCoinCount;i++)
			{
				coinValue = enemyParams.moneyBonus / nCoinCount;
				presentCoin = Instantiate(coinPrefab,tmpGameController.transform.position,tmpGameController.transform.rotation) as GameObject;
				presentCoin.SendMessage ("CoinValueSetting", coinValue);
			}
		}
	}

	public void MonsterTypeSetting(string boss){
		if (boss =="boss"){
			enemyParams.monsterType = "boss";
		}else{
			enemyParams.monsterType = "normal";	
		}

		print(enemyParams.monsterType);
	}
}
