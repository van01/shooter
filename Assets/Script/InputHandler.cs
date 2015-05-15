using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour {
	private bool scrInputActive = true;

	public void DisableScrInput(){
		scrInputActive = false;
	}

	public void EnableScrInput(){
		scrInputActive = true;
	}

	public void ScrInputActiveChange(){
		if (scrInputActive == true) scrInputActive = false;
		if (scrInputActive == false) scrInputActive = true;
	}

	void HitZoneInput(){
		if (scrInputActive == true){
			this.SendMessage("PlayerAttack");
			print ("Clicked");
		}
	}
}