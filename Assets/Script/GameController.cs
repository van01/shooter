using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		this.gameObject.SendMessage ("GameStateControll", "Battle");
	}
}
