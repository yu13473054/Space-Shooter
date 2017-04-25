using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	public float speed;
	private Rigidbody playerRb;

	void Start(){
		playerRb = GetComponent<Rigidbody>();
	}

	void FixedUpdate(){
		float horf = Input.GetAxis ("Horizontal");
		float verf = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (horf, 0, verf);
		playerRb.velocity = movement*speed;
	}
}
