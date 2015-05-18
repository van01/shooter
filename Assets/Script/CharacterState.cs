using UnityEngine;
using System.Collections;

public class CharacterState : MonoBehaviour {

	public enum State{
		Spawn,
		Idle,
		Chase,
		Attack,
		Dead,
	}
	
	public State currentState;

	public virtual void CharacterStateControll(string i){
		if (i == "Spawn")
			currentState = State.Spawn;
		if (i == "Idle")
			currentState = State.Idle;
		if (i == "Chase")
			currentState = State.Chase;
		if (i == "Attack")
			currentState = State.Attack;
		if (i == "Dead")
			currentState = State.Dead;

		CheckCharacterState();
	}

	public void CheckCharacterState(){
		switch(currentState){
		case State.Spawn:
			SpawnAction();
			break;
			
		case State.Chase:
			ChaseAction();
			break;
			
		case State.Idle:
			IdleAction();
			break;
			
		case State.Attack:
			AttackAction();
			break;
			
		case State.Dead:
			DeadAction();
			break;
		}
	}

	public virtual void SpawnAction(){
		print ("Character Spawn");
	}

	public virtual void ChaseAction(){
		print ("Character Chase");
	}

	public virtual void IdleAction(){
		SendMessage("ChangeAni", CharacterAni.IDLE);
	}

	public virtual void AttackAction(){
		SendMessage("StartBattle");
	}

	public virtual void DeadAction(){
		print ("Character Dead");
	}
}