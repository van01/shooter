using UnityEngine;
using System.Collections;

public class PlayerAI : MonoBehaviour {

	GameObject target;

	// Use this for initialization
	void Start () {
		PlayerParams mparams = new PlayerParams();
	}

	public void SearchEnemy(){
		target = GameObject.FindGameObjectWithTag("Enemy");
	}
	
	public GameObject GetCurrentTarget(){
		return target.gameObject;
	}
}
