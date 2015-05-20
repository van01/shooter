using UnityEngine;
using System.Collections;

public class CoinHandler : MonoBehaviour {

	private GameObject tmpGameController;
	private Vector3 mousePosition;

	void Start(){
		tmpGameController = GameObject.Find("GameController");
	}

	void OnMouseDown(){
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		
		if (Physics.Raycast(ray, out hit)){
			float mousePositionx = this.transform.position.x;
			float mousePositiony = this.transform.position.y;
			mousePosition = new Vector3(mousePositionx,mousePositiony,0);
		
			tmpGameController.SendMessage("CoinHitValue", mousePosition);
			Destroy(gameObject);

			print (mousePosition);
		}
	}
}
