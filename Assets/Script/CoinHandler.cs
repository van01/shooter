using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinHandler : MonoBehaviour {

	private GameObject tmpGameController;
	private int nCoinValue;

	public float nCoinAutoGetDelay = 5.0f;

	void Start(){
		tmpGameController = GameObject.Find("GameController");
		StartCoroutine(CoinAutoGet());
	}
	
	void OnMouseDown(){
		Vector3 mousePosition;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit)){
			float mousePositionx = Input.mousePosition.x;
			float mousePositiony = Input.mousePosition.y;
			mousePosition = new Vector3(mousePositionx,mousePositiony,0);

			Debug.DrawRay(ray.origin,ray.direction*10,Color.red);

			tmpGameController.SendMessage("HUDCoinValueSetting", nCoinValue);
			tmpGameController.SendMessage("CoinHitValue", mousePosition);

			Destroy(gameObject);
		}
	}

	public void CoinValueSetting(int nValue){
		nCoinValue = nValue;
	}

	IEnumerator CoinAutoGet(){
		yield return new WaitForSeconds(nCoinAutoGetDelay);
		Vector3 pos = Camera.main.WorldToScreenPoint(this.transform.position);

		tmpGameController.SendMessage("HUDCoinValueSetting", nCoinValue);
		tmpGameController.SendMessage("CoinHitValue", pos);

		Destroy(gameObject);
	}
}
