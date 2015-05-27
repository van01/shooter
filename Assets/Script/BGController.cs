using UnityEngine;
using System.Collections;

public class BGController : MonoBehaviour {

	public GameObject[] testStage;

	private GameObject presentStage;
	private Transform tmpStagePosition;
	private GameObject tmpPresentStage;

	public void StageDraw(int nStageNumber){
		if (testStage.Length < nStageNumber){
			InitializeStageDraw(tmpStagePosition);
		}else{
			Destroy(presentStage);
			presentStage = Instantiate(testStage[nStageNumber-1], tmpStagePosition.position, tmpStagePosition.rotation) as GameObject;
		}
	}

	private void InitializeStageDraw(Transform StartStagePosition){
		tmpStagePosition = StartStagePosition;
		Destroy(presentStage);
		presentStage = Instantiate(testStage[0], tmpStagePosition.position, tmpStagePosition.rotation) as GameObject;

	}
}
