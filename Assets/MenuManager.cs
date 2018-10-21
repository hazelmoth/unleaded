using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public GameObject optionsPanel;

	void Start () {
		optionsPanel.SetActive (false);
	}

	void Update () {
		
	}

	public void StartGame ()
	{
		SceneManager.LoadScene ("main");
	}

	public void ActivateOptionsPanel ()
	{
		optionsPanel.SetActive (true);
	}

	public void DeactivateOptionsPanel ()
	{
		optionsPanel.SetActive (false);
	}

	public void QuitGame ()
	{
		Application.Quit ();
	}
}
