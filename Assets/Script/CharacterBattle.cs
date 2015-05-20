using UnityEngine;
using System.Collections;

public class CharacterBattle : MonoBehaviour {

	protected float attackDelay = 0f;

	protected PlayerParams myParams;
	protected MonsterParams enemyParams;

	protected CharacterState myState;

	public virtual void StartBattle(){

	}

	protected IEnumerator BattleBegins(){
		if (myState.currentState == CharacterState.State.Attack){
			DoBattle();

			yield return new WaitForSeconds(attackDelay);
		}
	}

	public virtual void DoBattle(){

	}
}
