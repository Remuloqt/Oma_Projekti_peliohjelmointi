using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour {

	public float shootSpeed = 10f;

	public PlayerMove player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerMove> ();
		if (player.transform.localScale.x < 0) {
			shootSpeed = -shootSpeed;
		}
	}

	void Update(){

		GetComponent<Rigidbody2D> ().velocity = new Vector2 (shootSpeed, GetComponent<Rigidbody2D> ().velocity.y);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Destroy (gameObject);
	}


}