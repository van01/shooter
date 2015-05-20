using UnityEngine;
using System.Collections;

public class MonsterBattle : CharacterBattle {

	public GameObject coinPrefab;
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
			nCoinCount = Random.Range(10,20);
			for(int i=0;i<=nCoinCount;i++)
			{
				presentCoin = Instantiate(coinPrefab,tmpGameController.transform.position,tmpGameController.transform.rotation) as GameObject;
			}
		} else{
			nCoinCount = Random.Range(3,5);
			for(int i=0;i<=nCoinCount;i++)
			{
				presentCoin = Instantiate(coinPrefab,tmpGameController.transform.position,tmpGameController.transform.rotation) as GameObject;
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
