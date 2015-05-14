using UnityEngine;
using System.Collections;

public class GameStateController : MonoBehaviour {
	public enum GameState{
		Appear,
		Battle,
		BossBattle,
		Menu,
	}

	public GameState state;

	public void GameStateControll(string i){
		if (i == "Appear")
			state = GameState.Appear;
		if (i == "Battle")
			state = GameState.Battle;
		if (i == "BossBattle")
			state = GameState.BossBattle;
		if (i == "Menu")
			state = GameState.Menu;

		switch(state){
		case GameState.Appear:
			print ("Appear Start");
			break;

		case GameState.Battle:
			print ("Battle Start");
			break;

		case GameState.BossBattle:
			print ("Boss Battle Start");
			break;

		case GameState.Menu:
			print ("Menu call");
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
