using UnityEngine;
using System.Collections;

public class TownMenuController : MonoBehaviour {

	public GameObject Skill;
	public GameObject Equip;

	void Start(){
		Skill.SetActive (true);
	}

	public void ShowSkillTap(){
		Skill.SetActive (true);
		Equip.SetActive (false);
	}

	public void ShowEquipTap(){
		Skill.SetActive (false);
		Equip.SetActive (true);
	}
}
