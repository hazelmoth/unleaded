using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public GameObject endGamePanel;
	public GameObject pauseMenuPanel;
	public GameObject startPanel;

	public Text endGameDistanceText;
	public Text uiDistanceText;

	float distanceTraveled; // in kilometers!
	bool isPaused = false;
	bool gameOver = false;

	void Start () {
		Time.timeScale = 0f; // Start with the start panel open
		distanceTraveled = -0.4f; // To account for the two tiles that are loaded immediately

		endGamePanel.SetActive (false);
		pauseMenuPanel.SetActive (false);
		startPanel.SetActive (true);
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (isPaused)
			{
				UnpauseGame();
			}
			else if (!gameOver)
			{
				PauseGame ();
			}
		}
	}

	public void ExitStartPanel ()
	{
		startPanel.SetActive (false);
		Time.timeScale = 1f;
	}

	public void ActivateEndGamePanel ()
	{
		gameOver = true;
		Time.timeScale = 0f;
		endGamePanel.SetActive (true);
		endGameDistanceText.text = (distanceTraveled.ToString ("0.0") + " km traveled");
	}

	public void ExitToMenu ()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene ("menu");
	}

	public void RestartGame ()
	{
		gameOver = false;
		Time.timeScale = 1f;
		SceneManager.LoadScene ("main");
	}

	public void IncrementDistance ()
	{
		distanceTraveled += 0.2f;
		uiDistanceText.text = distanceTraveled.ToString ("0.0") + " km";
	}

	public void PauseGame ()
	{
		isPaused = true;
		Time.timeScale = 0f;
		pauseMenuPanel.SetActive (true);
	}

	public void UnpauseGame ()
	{
		isPaused = false;
		Time.timeScale = 1f;
		pauseMenuPanel.SetActive (false);
	}
}
