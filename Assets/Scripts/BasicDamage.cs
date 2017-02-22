using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDamage : MonoBehaviour, IDamageable {

	public int hitPoints = 1;
	//public GameObject explosionPrefab;
	public int scoreValue = 100;

	public void Damage(int value)
	{
		hitPoints -= value;
		if(hitPoints <= 0)
		{
			Kill ();
		}
	}

	public void Kill()
	{
		//GameObject.Instantiate (explosionPrefab, transform.position, Quaternion.identity);
		Destroy(gameObject);

		GameObject.Find("GameManager").GetComponent<GameManager>().AddScore(scoreValue);
	}

}
