using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;
using System.Collections.Generic;

public class GameIntro : MonoBehaviour {

	public GameObject Teddy;
	public List<Transform> teddyPoints = new List<Transform>();
	public PlatformerCharacter2D teddyCharacter;
	public Platformer2DUserControl teddyControl;
	public CircleCollider2D col1;
	public BoxCollider2D col2;
	public Rigidbody2D	rig;
	public Camera2DFollow cameraFollow;

	public GameObject roomDoor;

	// Use this for initialization
	IEnumerator Start () {
		iTween.RotateTo(roomDoor,iTween.Hash("y",60,"time",1,"easetype",iTween.EaseType.easeInExpo));

		yield return new WaitForSeconds(0.5f);
		iTween.MoveTo(Teddy,iTween.Hash("position",teddyPoints[0].position,"time",1,"easetype",iTween.EaseType.linear));

		yield return new WaitForSeconds(1);
		GameObject.Destroy(teddyPoints[0].gameObject);
		teddyPoints.RemoveAt(0);
		iTween.MoveTo(Teddy,iTween.Hash("position",teddyPoints[0].position,"time",3,"easetype",iTween.EaseType.linear));

		yield return new WaitForSeconds(3);
		GameObject.Destroy(teddyPoints[0].gameObject);
		teddyPoints.RemoveAt(0);

		teddyCharacter.enabled = true;
		teddyControl.enabled = true;
		col1.enabled = true;
		col2.enabled = true;
		rig.WakeUp();
		cameraFollow.enabled = true;

		roomDoor.GetComponent<EdgeCollider2D>().enabled = true;

		iTween.RotateTo(roomDoor,iTween.Hash("y",90,"time",1,"easetype",iTween.EaseType.easeInExpo));
	}
}
