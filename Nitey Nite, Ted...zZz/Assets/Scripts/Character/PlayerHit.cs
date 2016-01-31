using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHit : MonoBehaviour {

	public void DetectedHit(){
		StartCoroutine("Hit");
	}
	public IEnumerator Hit(){
		Debug.Log("PLAYER HIT");	
		iTween.CameraFadeAdd();
		iTween.CameraFadeTo(1,1);
		yield return new WaitForSeconds(1);
		SceneManager.LoadScene("Death");
	}
}
