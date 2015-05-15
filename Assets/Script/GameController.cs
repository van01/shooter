using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject playerPrefab;
	public GameObject startPosition;

	Transform tmpStartPosition;

	GameObject player;

	
	// Use this for initialization
	void Awake() {
		tmpStartPosition = startPosition.transform;
		MakePlayer();
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


}
