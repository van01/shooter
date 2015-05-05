using UnityEngine;
using System.Collections;

public class GameStateController : MonoBehaviour {
	public enum GameState{
		Battle,
		BossBattle,
		TownMenu,
	}

	public GameState state;

	public void GameStateControll(string i){
		if (i == "Battle")
			state = GameState.Battle;
		if (i == "BossBattle")
			state = GameState.BossBattle;
		if (i == "TownMenu")
			state = GameState.TownMenu;

		switch(state){
		case GameState.Battle:
			print ("Battle Start");
			break;

		case GameState.BossBattle:
			print ("Boss Battle Start");
			break;

		case GameState.TownMenu:
			print ("Town Menu call");
			break;
		}
	}


	//test
	public void StateBattle(){
		GameStateControll ("Battle");
	}
	public void StateBossBattle(){
		GameStateControll ("BossBattle");
	}

}
