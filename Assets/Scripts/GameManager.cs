using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	private int score = 0;
	private int health = 5;

	public Text scoreValueObject;
	public Text HealthValueObject;

	public GameObject playerPrefab;
	Vector3 position = new Vector3(-4.37f, 3.5f, 0f);

	// Use this for initialization
	void Start () {
		HealthValueObject.text = health.ToString ();
		GameObject spawnPlayerPrefab = Instantiate(playerPrefab);
		spawnPlayerPrefab.transform.position = position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddScore(int scoreInrease)
	{
		score += scoreInrease;
		scoreValueObject.text = score.ToString ();
	}

	public void takeHealth(int Healthdecrease)
	{
		if (health == 0) {
			//SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			StartCoroutine (levelChange());
		} 
		else {
			health -= Healthdecrease;
			HealthValueObject.text = health.ToString ();
			Debug.Log("Respawn Player");
			GameObject spawnPlayerPrefab = Instantiate(playerPrefab);
			spawnPlayerPrefab.transform.position = position;

		}
	}

	IEnumerator levelChange()
	{
		PlayerPrefs.SetInt ("score", score);
		yield return SceneManager.LoadSceneAsync("End");
	}
}
