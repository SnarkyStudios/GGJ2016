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
		StartCoroutine("AttackSequence");
	}

	void CurtainClosed (){
		Debug.Log(gameObject.tag + " || " + anim.GetBool("Shrink"));
		if(gameObject.tag == "Boss" && anim.GetBool("Shrink") == false){
			anim.SetBool("Shrink", true);
		}
		else{
			GetComponent<PlayerDetector>().enabled = false;
			anim.SetBool("Distance", false);
		}
	}

	IEnumerator AttackSequence(){
		yield return new WaitForSeconds(attackRate);

		if(anim.GetBool("Distance") == true){
			anim.SetBool("Attack",true);
			if(playerInDanger){
				PlayerHit.Hit();
			}
			yield return new WaitForSeconds(1);
			anim.SetBool("Attack", false);
		}

		StartCoroutine("AttackSequence");
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			playerInDanger = true;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if(other.tag == "Player"){
			playerInDanger = false;
		}
	}
}
