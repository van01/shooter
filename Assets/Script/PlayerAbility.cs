using UnityEngine;
using System.Collections;

public class PlayerAbility : MonoBehaviour {

	private HUDController tmpHudController;

	PlayerParams myParams = new PlayerParams();

	public void SetParams (PlayerParams tPrams){
		myParams = tPrams;
	}

	public PlayerParams GetParams(){
		return myParams;
	}

	void Start(){
		tmpHudController = GameObject.Find("GameController").GetComponent<HUDController>();
	}

	void Update(){
		tmpHudController.UpdatePlayerInfo(myParams);
	}
}
