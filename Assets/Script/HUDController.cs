using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDController : MonoBehaviour {
	public GameObject HUD;
	public GameObject townMenu;
	public GameObject playerInfoTxt;
	public GameObject monsterNameTxt;
	public GameObject monsterHPTxt;

	public GameObject stageInfoTxt;
	public GameObject BattleInfoTxt;

	private GameObject monsterHitTxt;
	public GameObject monsterHitTxtPrefab;
	public GameObject monsterHitTxtStart;
	private Transform tmpMonsterHitTxtStart;

	private GameObject coinHitTxt;
	public GameObject coinHitTxtPrefab;
	private int nCoinValue;

	public Scrollbar GUIMonsterHealthBar;

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
		monsterNameTxt.GetComponent<Text>().text = pParams.Name.ToString();
		monsterHPTxt.GetComponent<Text>().text = pParams.curHP.ToString();
	}


	public void MonsterHitDamage(int nDamage){
		monsterHitTxt = Instantiate(monsterHitTxtPrefab, tmpMonsterHitTxtStart.position, tmpMonsterHitTxtStart.rotation) as GameObject;
		monsterHitTxt.GetComponent<RectTransform>().SetParent(HUD.transform);
		monsterHitTxt.GetComponent<Text>().text = nDamage.ToString();
	}

	public void CoinHitValue(Vector3 nMousePosition){
		coinHitTxt = Instantiate(coinHitTxtPrefab, nMousePosition, gameObject.transform.rotation) as GameObject;
		coinHitTxt.GetComponent<RectTransform>().SetParent(HUD.transform);
		coinHitTxt.GetComponent<Text>().text = nCoinValue.ToString();
	}

	public void HUDCoinValueSetting(int nSettingCoinValue){
		nCoinValue = nSettingCoinValue;
	}

	public void UpdateStageInfo(int nStageNumber){
		stageInfoTxt.GetComponent<Text>().text = nStageNumber.ToString();
	}

	public void UpdateBattleInfo(int nBattleNumber){
		int nMaxBattle = GetComponent<GameController>().maxBattle;
		if (nMaxBattle >= nBattleNumber)
			BattleInfoTxt.GetComponent<Text>().text = nBattleNumber.ToString() + "/" + nMaxBattle;
		else
			BattleInfoTxt.GetComponent<Text>().text = "Boss Battle";
	}

	public void UpdateHealthBar(float nEnemyCurHpPer){
		GUIMonsterHealthBar.size = nEnemyCurHpPer;
	}
}
