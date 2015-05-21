using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour {

	public GameObject monsterPosition;

	public GameObject testPresentMonster1;
	public GameObject testPresentMonster2;
	public GameObject testPresentMonster3;
	public GameObject testPresentMonster4;
	public GameObject testPresentMonster5;

	private int rPresentMonNumber = 0;

	private GameObject presentMonster;
	private GameObject MonsterPrefab;

	Transform tmpMonsterPostion;

	void Awake(){
		tmpMonsterPostion = monsterPosition.transform;
	}

	public void MonsterMaker(){
		RandomMonster();
		RandomMonsterHandler();
		MakeMonster();
		presentMonster.SendMessage("MonsterTypeSetting", "normal");
	}

	public void BossMonsterMaker(){
		RandomMonster();
		RandomMonsterHandler();
		MakeMonster();
		presentMonster.SendMessage("MonsterTypeSetting", "boss");
	}

	public void MonsterDestroyer(){
		presentMonster.SendMessage("MonsterDie"); 
		GameObject.Destroy(presentMonster);
	}

	void RandomMonster(){
		rPresentMonNumber = Random.Range(1,6);
	}

	void RandomMonsterHandler(){
		if (rPresentMonNumber == 1)
			MonsterPrefab = testPresentMonster1;
		if (rPresentMonNumber == 2)
			MonsterPrefab = testPresentMonster2;
		if (rPresentMonNumber == 3)
			MonsterPrefab = testPresentMonster3;
		if (rPresentMonNumber == 4)
			MonsterPrefab = testPresentMonster4;
		if (rPresentMonNumber == 5)
			MonsterPrefab = testPresentMonster5;
	}

	void MakeMonster(){
		presentMonster = Instantiate(MonsterPrefab, tmpMonsterPostion.position, tmpMonsterPostion.rotation) as GameObject;
		presentMonster.SendMessage("StartBattle");
	}
	
}
