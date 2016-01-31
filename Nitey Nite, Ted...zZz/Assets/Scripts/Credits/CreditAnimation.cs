using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CreditAnimation : MonoBehaviour {

	public GameObject teddy;
	public Transform target;

	// Use this for initialization
	IEnumerator Start () {
		iTween.MoveTo(teddy,iTween.Hash("time",40,"position",target.position,"easetype",iTween.EaseType.linear));
		yield return new WaitForSeconds(39);
		teddy.GetComponent<Animator>().SetBool("Blanket",true);
		yield return new WaitForSeconds(4);
		StartCoroutine("EndCredits");
	}

	IEnumerator EndCredits(){
		iTween.AudioTo(GameObject.Find("Music"),0,1,1);
		iTween.CameraFadeAdd();
		iTween.CameraFadeTo(1,1);
		yield return new WaitForSeconds(1.5f);
		Destroy(GameObject.Find("Music"));
		SceneManager.LoadScene(0);
	}
}
