using UnityEngine;
using System.Collections;

public class CharacterBattle : MonoBehaviour {

	protected float attackDelay = 2.0f;

	protected CharacterParams myParams;
	protected CharacterParams enemyParams;

	protected CharacterState myState;

	public virtual void StartBattle(){

	}

	protected IEnumerator BattleBegins(){
		while (myState.currentState == CharacterState.State.Attack){
			DoBattle();

			yield return new WaitForSeconds(attackDelay);
		}
	}

	public virtual void DoBattle(){

	}
}
