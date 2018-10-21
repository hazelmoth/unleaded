using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Car : MonoBehaviour {

	public float maxGas = 100f;
	public float currentGas = 100f;
	public Slider fuelSlider;
	public GameManager gameManager;

	float fuelConsumptionRate = 3f;

	void Update () {
		currentGas -= fuelConsumptionRate * Time.deltaTime;
		fuelSlider.value = currentGas / maxGas;

		if (currentGas <= 0)
		{
			gameManager.ActivateEndGamePanel ();
		}
	}

	public void HitGasPickup (float value)
	{
		currentGas += value;
		if (currentGas > maxGas) {currentGas = maxGas;}
	}
		
}
