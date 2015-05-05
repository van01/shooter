using UnityEngine;
using System.Collections;

public class HUDInputController : MonoBehaviour {

	
	void TownMenuButton(){
		this.gameObject.SendMessage ("ShowTownMenu");
		this.gameObject.SendMessage ("GameStateControll", "TownMenu");

		print ("Town Menu Select");
	}
}
