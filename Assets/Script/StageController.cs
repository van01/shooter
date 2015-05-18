using UnityEngine;
using System.Collections;

public class StageController : MonoBehaviour {

	private int nPresentStage;
	private int nPresentBattle;

	void Start () {
	
	}
	
	public void StageHandler(int nMBattle){
		if(nMBattle < nPresentBattle){
			nPresentStage++;
			SendMessage("GetPresentStage", nPresentStage);
			nPresentBattle = 1;
			SendMessage("GetPresentBattle", nPresentBattle);

			print (nPresentStage + " - " + nPresentBattle);
		} else if (nMBattle == nPresentBattle) {
				SendMessage("BossBattleOn");

				nPresentBattle++;
				SendMessage("GetPresentBattle", nPresentBattle);
				
				print (nPresentStage + " Stage Boss Battle");
		} else {
			nPresentBattle++;
			SendMessage("GetPresentBattle", nPresentBattle);

			print (nPresentStage + " - " + nPresentBattle);
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
