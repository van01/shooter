using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDController : MonoBehaviour {
	public GameObject townMenu;

	public GameObject playerInfoTxt;
	public GameObject monsterInfoTxt;

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
}
