using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveGame : MonoBehaviour {

	public void ReStart()
	{
		Debug.Log("Start game");

		StartCoroutine (levelChange());
	}

	public void QuitGame()
	{
		Application.Quit ();
	}

	IEnumerator levelChange()
	{
		PlayerPrefs.SetInt ("score", 0);
		yield return SceneManager.LoadSceneAsync("Shooter");
	}

}