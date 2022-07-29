using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
	public void WinGame()
	{
		StartCoroutine(RestartLevel());
	}

	public void LoseGame()
	{
		StartCoroutine(RestartLevel());
	}

	IEnumerator RestartLevel()
	{
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
