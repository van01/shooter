using UnityEngine;
using System.Collections;

public class MercenaryAbility : MonoBehaviour {
	
	private HUDController tmpHudController;
	
	MercenaryParams myParams = new MercenaryParams();
	
	public void SetParams (MercenaryParams tPrams){
		myParams = tPrams;
	}
	
	public MercenaryParams GetParams(){
		return myParams;
	}
	
	void Start(){
		tmpHudController = GameObject.Find("GameController").GetComponent<HUDController>();
	}
}
