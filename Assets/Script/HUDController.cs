using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDController : MonoBehaviour {
	public GameObject HUD;

	public GameObject townMenu;

	public GameObject playerInfoTxt;
	public GameObject monsterInfoTxt;

	private GameObject monsterHitTxt;
	public GameObject monsterHitTxtPrefab;
	public GameObject monsterHitTxtStart;
	private Transform tmpMonsterHitTxtStart;

	private GameObject coinHitTxt;
	public GameObject coinHitTxtPrefab;

	void Start(){
		tmpMonsterHitTxtStart = monsterHitTxtStart.transform;
	}

	public void ShowTownMenu(){
		townMenu.SetActive (true);
	}
	public void HideTownMenu(){
		townMenu.SetActive (false);
	}

	public void UpdatePlayerInfo(PlayerParams pParams){
		playerInfoTxt.GetComponent<Text>().text = pParams.Name.ToString() + " / Level: " + pParams.level.ToString();
	}

	public void UpdateMonsterInfo(MonsterParams pParams){
		monsterInfoTxt.GetComponent<Text>().text = pParams.Name.ToString() + " / HP: " + pParams.curHP.ToString();
	}


	public void MonsterHitDamage(int nDamage){
		monsterHitTxt = Instantiate(monsterHitTxtPrefab, tmpMonsterHitTxtStart.position, tmpMonsterHitTxtStart.rotation) as GameObject;
		monsterHitTxt.GetComponent<RectTransform>().SetParent(HUD.transform);
		monsterHitTxt.GetComponent<Text>().text = nDamage.ToString();
	}

	public void CoinHitValue(Vector3 nMousePosition){
		coinHitTxt = Instantiate(coinHitTxtPrefab, nMousePosition, gameObject.transform.rotation) as GameObject;
		coinHitTxt.GetComponent<RectTransform>().SetParent(HUD.transform);
		coinHitTxt.GetComponent<Text>().text = "1112";
	}
}
