using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryByContact : MonoBehaviour {
	public GameObject explosion;
	public GameObject playerExplosion;

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Boundary"){
			return;
		}else if(other.tag=="Player"){
			//Debug.Log (other.tag);
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
		}
		Instantiate (explosion, transform.position, transform.rotation);
		Destroy(other.gameObject);
		Destroy (gameObject);
	}
}
