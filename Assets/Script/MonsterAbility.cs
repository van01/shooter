using UnityEngine;
using System.Collections;

public class MonsterAbility : MonoBehaviour {

	private HUDController tmpHudController;

	MonsterParams myParams = new MonsterParams();
	
	public void SetParams (MonsterParams tPrams){
		myParams = tPrams;
	}
	
	public MonsterParams GetParams(){
		return myParams;
	}

	void Start(){
		tmpHudController = GameObject.Find("GameController").GetComponent<HUDController>();
	}
	void Update(){
		tmpHudController.UpdateMonsterInfo(myParams);
	}
}
