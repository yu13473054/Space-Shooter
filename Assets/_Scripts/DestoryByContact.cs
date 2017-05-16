using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryByContact : MonoBehaviour {
	public GameObject explosion;
	public GameObject playerExplosion;
	public int destroyScore;

	private GameController gameCtrl;

	// Use this for initialization
	void Start () {
		GameObject gameCtrlObj = GameObject.FindWithTag ("GameController");
		if(gameCtrlObj!=null){
			gameCtrl = gameCtrlObj.GetComponent<GameController> ();
		}
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Boundary"){
			return;
		}else if(other.tag=="Player"){
			//Debug.Log (other.tag);
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
		}
		gameCtrl.AddScore (destroyScore);
		Instantiate (explosion, transform.position, transform.rotation);
		Destroy(other.gameObject);
		Destroy (gameObject);
	}
}
