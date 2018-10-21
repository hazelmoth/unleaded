using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasPickup : MonoBehaviour {

	public float pickupValue = 100f;

	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, 3, 0, Space.World);
	}

	void OnTriggerEnter (Collider collider)
	{
		Car car = collider.GetComponent<Car> ();
		if (car)
		{
			car.HitGasPickup(pickupValue);
			Destroy (gameObject);
		}
	}
}
