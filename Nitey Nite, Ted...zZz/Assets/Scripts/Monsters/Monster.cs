using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {

	public float attackRate;
	private bool active;
	private Animator anim;

	private bool playerInDanger;

	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator>();
		if(attackRate > 0)
			StartCoroutine("AttackSequence");
	}

	void CurtainClosed (){
		if(gameObject.tag == "Boss" && anim.GetBool("Shrink") == false){
			anim.SetBool("Shrink", true);
		}
		else{
			GetComponent<PlayerDetector>().enabled = false;
			anim.SetBool("Distance", false);
			GetComponent<CircleCollider2D>().enabled = false;
		}
	}

	void SmallAttackRecovery(){
		StartCoroutine("BeginRecovery");
	}

	IEnumerator BeginRecovery(){
		yield return new WaitForSeconds(2);
		anim.SetBool("Recover",true);

		yield return new WaitForSeconds(2);
		anim.SetBool("Recover",false);
	}

	IEnumerator AttackSequence(){
		yield return new WaitForSeconds(attackRate);

		if(anim.GetBool("Distance") == true){
			anim.SetBool("Attack",true);
			if(playerInDanger){
				GameObject.FindGameObjectWithTag("Player").SendMessage("DetectedHit");
			}
			yield return new WaitForSeconds(1);
			anim.SetBool("Attack", false);
		}

		StartCoroutine("AttackSequence");
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			if(attackRate == 0){
				GameObject.FindGameObjectWithTag("Player").SendMessage("DetectedHit");
			}
			playerInDanger = true;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if(other.tag == "Player"){
			playerInDanger = false;
		}
	}
}
