using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerControl : MonoBehaviour
{
	private Rigidbody playerRb;
	private float nextFire;
    private AudioSource boltFireAudio;

	public float speed;
	public Boundary boundary;
	public float tilt;
	public GameObject shot;
	public Transform spotSpawn;
	public float fireRate ;

	void Start ()
	{
		playerRb = GetComponent<Rigidbody> ();
        boltFireAudio = GetComponent<AudioSource>();
	}

	void Update(){
		if(Input.GetButton("Fire1") && Time.time>nextFire){
			nextFire = Time.time + fireRate;
			Instantiate (shot,spotSpawn.position,spotSpawn.rotation);
            boltFireAudio.Play();
		}
	}


	void FixedUpdate ()
	{
		float horf = Input.GetAxis ("Horizontal");
		float verf = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (horf, 0, verf);
		playerRb.velocity = movement * speed;

		playerRb.position = new Vector3 (
			Mathf.Clamp (playerRb.position.x, boundary.xMin, boundary.xMax), 
			0, 
			Mathf.Clamp (playerRb.position.z, boundary.zMin, boundary.zMax)
		);

		playerRb.rotation = Quaternion.Euler (0, 0, playerRb.velocity.x * -tilt);
	}
}
