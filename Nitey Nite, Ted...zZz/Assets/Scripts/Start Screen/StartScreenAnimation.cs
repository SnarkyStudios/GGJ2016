using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartScreenAnimation : MonoBehaviour {

	public GameObject target;
	public Transform walkTarget;
	public Animator curtainAnim;
	private Animator anim;

	public GameObject bg;
	public GameObject title;
	public GameObject instructions;

	public bool listenForClick = false;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		iTween.MoveTo(target,iTween.Hash("time",5,"x",walkTarget.position.x,"delay",1,"easetype",iTween.EaseType.linear,"oncomplete","reachedPoint"));
	}

	void reachedPoint(){
		anim.SetBool("Blanket",true);
		StartCoroutine("delayCurtain");
	}

	IEnumerator delayCurtain(){
		yield return new WaitForSeconds(1.2f);
		curtainAnim.SetBool("Close",true);

		yield return new WaitForSeconds(1);
		iTween.CameraFadeAdd();
		iTween.CameraFadeTo(1,1);

		yield return new WaitForSeconds(1);
		title.SetActive(true);
		instructions.SetActive(true);
		bg.SetActive(true);
		iTween.CameraFadeDestroy();
		listenForClick = true;

		yield return new WaitForSeconds(20);
		SceneManager.LoadScene(0);
	}

	void Update(){
		if(Input.anyKeyDown){
			SceneManager.LoadScene(1);
		}
	}
}
