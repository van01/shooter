using UnityEngine;
using System.Collections;

public class MonsterBattle : CharacterBattle {

	public GameObject coinPrefab;
	public float coinSpawnDelay = 0.1f;
	public GameObject coinParent;

	protected int coinValue;

	private GameObject presentCoin;

	private GameObject tmpGameController;
	private int coinCount = 0;

	void Start(){
		tmpGameController = GameObject.Find("GameController");
		coinParent = GameObject.Find("_CoinParent");
	}

	public override void StartBattle(){
		enemyParams = GetComponent<MonsterAbility>().GetParams();
	}

	public void MonsterTypeSetting(string boss){
		if (boss =="boss"){
			enemyParams.monsterType = "boss";
		}else{
			enemyParams.monsterType = "normal";	
		}
		
		print(enemyParams.monsterType);
	}

	public void MonsterDie(){

		if (enemyParams.monsterType == "boss"){
			coinCount = Random.Range(10,21);
			for(int i=0;i<=coinCount;i++)
			{
				//StartCoroutine("CoinSpawnHandler");
				CoinSpawnHandler();
				coinValue = enemyParams.moneyBonus / coinCount;
				presentCoin.SendMessage ("CoinValueSetting", coinValue);
			}
		} else{
			coinCount = Random.Range(3,6);
			for(int i=0;i<=coinCount;i++)
			{
				//StartCoroutine("CoinSpawnHandler");
				CoinSpawnHandler();
				coinValue = enemyParams.moneyBonus / coinCount;
				presentCoin.SendMessage ("CoinValueSetting", coinValue);
			}
		}
	}

	protected void CoinSpawnHandler(){		
		float rForceX = Random.Range(-2f,3f);
		float rForceY = Random.Range(2f,8f);
		float rForceZ = Random.Range(-2f,-6f);
		
		presentCoin = Instantiate(coinPrefab,tmpGameController.transform.position,Quaternion.Euler(90,0,0)) as GameObject;
		presentCoin.GetComponent<Rigidbody>().AddForce(new Vector3(rForceX,rForceY,rForceZ),ForceMode.Impulse);
		presentCoin.transform.SetParent(coinParent.transform);
	}
}
