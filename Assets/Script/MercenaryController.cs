using UnityEngine;
using System.Collections;

public class MercenaryController : MonoBehaviour {
	public GameObject shortMercenaryPosition;
	public GameObject middleMercenaryPosition;
	public GameObject longMercenaryPosition;

	public GameObject[] testMercenary;

	private GameObject presentMercenary;

	Transform tmpShortMercenaryPosition;
	Transform tmpMiddleMercenaryPosition;
	Transform tmpLongMercenaryPosition;
	Transform tmpMercenaryPosition;

	void Awake(){
		tmpShortMercenaryPosition = shortMercenaryPosition.transform;
		tmpMiddleMercenaryPosition = middleMercenaryPosition.transform;
		tmpLongMercenaryPosition = longMercenaryPosition.transform;
	}

	void MakeMercenary(int mercernaryID){
		presentMercenary = Instantiate(testMercenary[mercernaryID], tmpMercenaryPosition.position, tmpMercenaryPosition.rotation) as GameObject;
	}

	void SetMercenaryAttackType(string mercenaryAttackType){

	}
}
