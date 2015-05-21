using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDController : MonoBehaviour {
	public GameObject HUD;
	public GameObject townMenu;
	public GameObject playerTapDamageTxt;
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

	private string nCoinValue;

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
		playerTapDamageTxt.GetComponent<Text>().text = pParams.attack.ToString();
	}

	public void UpdateMonsterInfo(MonsterParams pParams){
		monsterNameTxt.GetComponent<Text>().text = pParams.Name.ToString();
		monsterHPTxt.GetComponent<Text>().text = pParams.curHP.ToString();
	}


	public void MonsterHitDamage(decimal nDamage){
		monsterHitTxt = Instantiate(monsterHitTxtPrefab, tmpMonsterHitTxtStart.position, tmpMonsterHitTxtStart.rotation) as GameObject;
		monsterHitTxt.GetComponent<RectTransform>().SetParent(HUD.transform);

		monsterHitTxt.GetComponent<Text>().text = nDamage.ToString();												//BigNumber Handler 적용 필요
	}

	public void CoinHitValue(Vector3 nMousePosition){
		coinHitTxt = Instantiate(coinHitTxtPrefab, nMousePosition, gameObject.transform.rotation) as GameObject;
		coinHitTxt.GetComponent<RectTransform>().SetParent(HUD.transform);
		coinHitTxt.GetComponent<Text>().text = nCoinValue;
	}

	public void HUDCoinValueSetting(decimal nSettingCoinValue){
		nCoinValue = nSettingCoinValue.ToString ();																	//BigNumber Handler 적용 필요
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
