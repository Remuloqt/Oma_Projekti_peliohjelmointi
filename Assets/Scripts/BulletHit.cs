using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour {

	public int damageValue = 1;

	void OnTriggerEnter2D(Collider2D c)
	{
		if(c.tag == "Enemy")
		{
			
			Destroy(gameObject);
			c.gameObject.GetComponent<IDamageable> ().Damage (damageValue);

		}
		else if(c.tag == "Level")
		{
			Destroy(gameObject);
		}

	}
}
