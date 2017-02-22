using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

	
	public float Speed = 3f;
	
	public Transform target;

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

	}

	// Update is called once per frame
	void Update(){

		target = GameObject.FindGameObjectWithTag ("Player").transform;
		Vector3 lookAt = target.position;
		lookAt.y = transform.position.y;


		anim.SetFloat ("Speed", Mathf.Abs (Speed));


		transform.LookAt (lookAt);
		transform.Rotate (new Vector3 (0, -90, 0), Space.Self);

		if (Vector3.Distance (transform.position, target.position) < 50f) {
			transform.Translate (new Vector3 (Speed * Time.deltaTime, 0, 0));
		}

	}
		
}
