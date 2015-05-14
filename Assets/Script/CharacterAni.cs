using UnityEngine;
using System.Collections;

public class CharacterAni : MonoBehaviour {

	public const int IDLE = 1;
	public const int MOVE = 2;
	public const int ATTACK = 3;
	public const int DEATH = 4;
	public const int SPAWN = 5;

	Animator anim;

	void Start(){
		anim = GetComponent<Animator>();
	}

	public void ChangeAni(int aniNum){
		anim.SetInteger("aniNumber", aniNum);

		if (aniNum == CharacterAni.ATTACK){
			StartCoroutine("SuccecssRoll");
		}
	}

	IEnumerator SuccecssRoll(){
		float attackWaitItme = anim.GetCurrentAnimatorStateInfo(0).length;

		yield return new WaitForSeconds(attackWaitItme);
		SendMessage("CharacterStateControll","Idle");
	}
}
