using UnityEngine;
using System.Collections;

public class CharacterInput : MonoBehaviour {

	void OnMouseDown(){
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		
		if (Physics.Raycast(ray, out hit)){
			if (hit.collider.CompareTag("Enemy")){
				print ("enemy click");	
			}

			if (hit.collider.CompareTag("Player")){
				print ("player click");
				
			}
		}
		
	}
}
