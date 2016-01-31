using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void Update(){
		if(Input.anyKeyDown){
			SceneManager.LoadScene("Game");
		}
	}
}
