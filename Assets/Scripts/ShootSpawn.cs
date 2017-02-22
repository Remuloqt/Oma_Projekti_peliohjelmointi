using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSpawn : MonoBehaviour {

	public GameObject BulletPrefab;

	public AudioSource shootSound;

	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1"))
		{
			GameObject.Instantiate (BulletPrefab, transform.position, Quaternion.identity);
			shootSound.Play ();
		}
	}


}
