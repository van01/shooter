using UnityEngine;
using System.Collections;

public class CharacterInputHandler : MonoBehaviour {

	private bool chaInputActive = true;

	void Start(){

	}

	void OnMouseDown(){
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		
		if (chaInputActive == true) {
			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider.CompareTag ("Enemy")) {
					print ("enemy click");	
				}
				
				if (hit.collider.CompareTag ("Player")) {
					print ("player click");
					
				}
			}
		}
	}

	public void DisableChaInput(){
		chaInputActive = false;
	}
	
	public void EnableChaInput(){
		chaInputActive = true;
	}

	public void ChaInputActiveChange(){
		if (chaInputActive == true) chaInputActive = false;
		if (chaInputActive == false) chaInputActive = true;
	}
}
