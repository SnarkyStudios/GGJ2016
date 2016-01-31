using UnityEngine;
using System.Collections;

public class PlayerDetector : MonoBehaviour {

	private Animator m_Anim;            // Reference to the player's animator component.

	public Transform player;
	public bool fear;
	private float distance = 5.0f;
	private bool playerClose;

	// Use this for initialization
	void Awake () {
		m_Anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(player.GetComponent<Animator>().GetBool("Blanket") && fear){
			playerClose = false;

			m_Anim.SetBool("Distance", false);
			return;
		}

		if(gameObject.tag == "Boss"){
			if(m_Anim.GetBool("Shrink") == true){
				//m_Anim.
			}
		}
		
		playerClose = (Vector3.Distance(transform.position,player.position) < distance);

		m_Anim.SetBool("Distance", playerClose);
	}
}
