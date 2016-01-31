using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CurtainCord : MonoBehaviour {

	private bool activated;

	public List<GameObject> cords = new List<GameObject>();

	public Transform player;
	private float distance = 3.5f;
	private bool playerClose;

	public Animator m_Anim; 
	
	// Update is called once per frame
	void Update () {
		if(activated)
			return;
		
		playerClose = (Vector3.Distance(transform.position,player.position) < distance);

		switchCords();

		if(playerClose && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Keypad0))){
			cords[0].SetActive(true);
			cords[1].SetActive(false);

			m_Anim.SetBool("Close",true);
			StartCoroutine("animateCord");
			activated = true;
		}
		//m_Anim.SetBool("Distance", playerClose);
	}

	IEnumerator animateCord(){
		iTween.MoveBy(cords[0],iTween.Hash("y",-0.2f,"time",0.5f));
		yield return new WaitForSeconds(0.5f);
		iTween.MoveBy(cords[0],iTween.Hash("y",0.2f,"time",0.5f));
		yield return new WaitForSeconds(0.5f);
		Destroy(this);
	}

	void switchCords(){
		if(playerClose){
			if(cords[0].activeSelf){
				cords[0].SetActive(false);
				cords[1].SetActive(true);
			}
		}
		else{
			if(cords[1].activeSelf){
				cords[0].SetActive(true);
				cords[1].SetActive(false);
			}
		}
	}
}
