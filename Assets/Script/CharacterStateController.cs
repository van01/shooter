using UnityEngine;
using System.Collections;

public class CharacterStateController : MonoBehaviour {

	public enum CharacterState{
		Spawn,
		Idle,
		Battle,
		Die,
	}
	
	public CharacterState state;

	public void CharacterStateControll(string i){
		if (i == "Spawn")
			state = CharacterState.Spawn;
		if (i == "Idle")
			state = CharacterState.Idle;
		if (i == "Battle")
			state = CharacterState.Battle;
		if (i == "Die")
			state = CharacterState.Die;
		
		switch(state){
		case CharacterState.Spawn:
			print ("Character Spawn");
			break;
			
		case CharacterState.Idle:
			print ("Character Idle");
			break;
			
		case CharacterState.Battle:
			print ("Character Battle");
			break;
			
		case CharacterState.Die:
			print ("Character Die");
			break;
		}
	}

}