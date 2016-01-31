using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			iTween.CameraFadeAdd();
			iTween.CameraFadeTo(1,1);
			StartCoroutine("FadeComplete");
		}
	}

	IEnumerator FadeComplete(){
		yield return new WaitForSeconds(1);
		SceneManager.LoadScene("EndAnimation");
	}
}
