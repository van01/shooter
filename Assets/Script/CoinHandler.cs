using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinHandler : MonoBehaviour {

	private GameObject tmpGameController;
	private Vector3 mousePosition;
	private Ray ray;
	private int nCoinValue;

	public RectTransform myRectT;

	void Start(){
		tmpGameController = GameObject.Find("GameController");
	}
	
	void OnMouseDown(){
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit)){
			float mousePositionx = Input.mousePosition.x;
			float mousePositiony = Input.mousePosition.y;
			mousePosition = new Vector3(mousePositionx,mousePositiony,0);

			Destroy(gameObject);
			Debug.DrawRay(ray.origin,ray.direction*10,Color.red);

			tmpGameController.SendMessage("HUDCoinValueSetting", nCoinValue);
			tmpGameController.SendMessage("CoinHitValue", mousePosition);

		}
	}

	public void CoinValueSetting(int nValue){
		nCoinValue = nValue;
	}
}
