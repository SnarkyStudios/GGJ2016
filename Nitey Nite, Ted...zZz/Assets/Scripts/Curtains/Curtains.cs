using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Curtains : MonoBehaviour {

	public List<GameObject> affectedMonster = new List<GameObject>();

	// Use this for initialization
	void Start () {
	
	}
	
	void CurtainClosed(){
		foreach(GameObject go in affectedMonster){
			go.SendMessage("CurtainClosed");
		}
	}	
}
