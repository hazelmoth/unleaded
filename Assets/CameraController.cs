using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Camera mainCamera;
	public Camera rearCamera;

	// Use this for initialization
	void Start () {
		mainCamera.enabled = true;
		rearCamera.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.C) && Time.timeScale == 1f)
		{
			EnableRearCamera ();
		}
		else if (Input.GetKeyUp(KeyCode.C))
		{
			DisableRearCamera ();
		}
	}

	void EnableRearCamera()
	{
		mainCamera.enabled = false;
		rearCamera.enabled = true;
	}

	void DisableRearCamera()
	{
		mainCamera.enabled = true;
		rearCamera.enabled = false;
	}
}
