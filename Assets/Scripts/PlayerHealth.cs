using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public int healthValue = 1;

	void OnTriggerEnter2D(Collider2D c)
	{

		if (c.gameObject.tag == "Enemy") 
		{
			Debug.Log ("osui");

			Kill ();

		}

	}

	public void Kill()
	{
		Destroy(gameObject);

		GameObject.Find ("GameManager").GetComponent<GameManager> ().takeHealth (healthValue);
	}




}
