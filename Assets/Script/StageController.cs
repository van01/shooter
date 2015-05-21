﻿using UnityEngine;
using System.Collections;

public class StageController : MonoBehaviour {

	private int nPresentStage;
	private int nPresentBattle;
		
	public void StageHandler(int nMBattle){
		if(nMBattle < nPresentBattle){
			nPresentStage++;
			SendMessage("GetPresentStage", nPresentStage);
			nPresentBattle = 1;
			SendMessage("GetPresentBattle", nPresentBattle);

			SendMessage("UpdateStageInfo", nPresentStage);
			SendMessage("UpdateBattleInfo", nPresentBattle);
		} else if (nMBattle == nPresentBattle) {
			SendMessage("BossBattleOn");

			nPresentBattle++;
			SendMessage("GetPresentBattle", nPresentBattle);
				
			SendMessage("UpdateStageInfo", nPresentStage);
			SendMessage("UpdateBattleInfo", nPresentBattle);
		} else {
			nPresentBattle++;
			SendMessage("GetPresentBattle", nPresentBattle);

			SendMessage("UpdateStageInfo", nPresentStage);
			SendMessage("UpdateBattleInfo", nPresentBattle);
		}
	}

	public void SetPresentStage(int nPStage){
		if (nPStage == 0)
			nPStage = 1;
		nPresentStage = nPStage;
	}

	public void SetPresentBattle(int nPBattle){
		nPresentBattle = nPBattle;
	}
}
