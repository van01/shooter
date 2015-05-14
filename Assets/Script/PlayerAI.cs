using UnityEngine;
using System.Collections;

public class PlayerAI : MonoBehaviour {

	GameObject target;

	// Use this for initialization
	void Start () {
		PlayerParams mparams = new PlayerParams();

		print (mparams.Name);
		print (mparams.attack);
		print (mparams.maxHP);

		target = GameObject.FindGameObjectWithTag("Enemy");
	}

	public void SearchEnemy(){
		target = GameObject.FindGameObjectWithTag("Enemy");
	}
	
	public GameObject GetCurrentTarget(){
		return target.gameObject;
	}
}
