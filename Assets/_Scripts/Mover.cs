using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
	public float speed;
	private Rigidbody boltRb;

	void Start () {
		boltRb = GetComponent<Rigidbody> ();
		boltRb.velocity = transform.forward * speed;
	}
	
}
