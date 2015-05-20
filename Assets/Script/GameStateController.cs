using UnityEngine;
using System.Collections;

public class GameStateController : MonoBehaviour {
	public enum GameState{
		Appear,
		Battle,
		BossBattle,
		BattleEnd,
		Menu,
	}

	public GameState state;
	private bool bBossBattle = false;

	public void GameStateControll(string i){
		if (i == "Appear")
			state = GameState.Appear;
		if (i == "Battle")
			state = GameState.Battle;
		if (i == "BossBattle")
			state = GameState.BossBattle;
		if (i =="BattleEnd")
			state = GameState.BattleEnd;
		if (i == "Menu")
			state = GameState.Menu;

		switch(state){
		case GameState.Appear:
			AppearAction();
			print ("Appear Start");
			break;

		case GameState.Battle:
			BattleAction();
			print ("Battle Start");
			break;

		case GameState.BossBattle:
			BossBattleAction();
			print ("Boss Battle Start");
			break;

		case GameState.BattleEnd:
			BattleEndAction();
			print ("Battle End");
			break;

		case GameState.Menu:
			print ("Menu call");
			break;
		}
	}

	public void StateBattle(){
		GameStateControll ("Battle");
	}

	public void StateBossBattle(){
		GameStateControll ("BossBattle");
	}


	void AppearAction(){
		if (bBossBattle == true) {
			GameStateControll ("BossBattle");
		}
		if (bBossBattle == false) {
			GameStateControll ("Battle");
		}
	}

	void BattleAction(){
		SendMessage("MonsterMaker");
	}

	void BattleEndAction(){
		if (bBossBattle == true){
			BossBattleOff();
		}
		SendMessage("MonsterDestroyer");
		SendMessage ("StageSetting");
		GameStateControll ("Appear");
	}

	void BossBattleAction(){
		SendMessage("BossMonsterMaker");
	}

	public void BossBattleOn(){
		bBossBattle = true;
	}

	public void BossBattleOff(){
		bBossBattle = false;
	}
}