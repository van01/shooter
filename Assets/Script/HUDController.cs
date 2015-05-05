using UnityEngine;
using System.Collections;

public class HUDController : MonoBehaviour {
	public GameObject townMenu;

	public void ShowTownMenu(){
		townMenu.SetActive (true);
	}
	public void HideTownMenu(){
		townMenu.SetActive (false);
	}
}
