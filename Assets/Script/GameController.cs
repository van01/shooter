using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject playerPrefab;
	public GameObject startPosition;

	private Transform tmpStartPosition;

	private GameObject player;

	public int presentStage = 0;
	public int presentBattle = 0;
	public int maxBattle = 10;
	
	// Use this for initialization
	void Awake() {
		tmpStartPosition = startPosition.transform;
		MakePlayer();
		StageSetting ();
	}

	void Start(){
		gameObject.SendMessage ("GameStateControll", "Appear");
	}

	void MakePlayer(){
		player = Instantiate(playerPrefab, tmpStartPosition.position, tmpStartPosition.rotation) as GameObject;
	}

	public void PlayerAttack(){
		player.SendMessage("CharacterStateControll", "Attack");
	}

	public void StageSetting(){
		gameObject.SendMessage ("SetPresentStage", presentStage);
		gameObject.SendMessage ("SetPresentBattle", presentBattle);
		gameObject.SendMessage ("StageHandler", maxBattle);
	}

	public void GetPresentStage(int nPStage){
		presentStage = nPStage;
	}

	public void GetPresentBattle(int nPBattle){
		presentBattle = nPBattle;
	}

	public void SendHudMonsterHitDamage(int nHitDamage){
		gameObject.SendMessage("MonsterHitDamage",nHitDamage);
	}

}
