using UnityEngine;
using System.Collections;

public class CharacterInputController : MonoBehaviour {

	public bool InputActive = true;
	
	void OnMouseDown(){
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		
		if (InputActive == true) {
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
	
	public void InputActiveController(string i){
		if (i == "true")
			InputActive = true;
		if (i == "false")
			InputActive = false;
		
		return;
	}
}
