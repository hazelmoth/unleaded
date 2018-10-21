using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStabilizer : MonoBehaviour {

	public WheelCollider wheelR;
	public WheelCollider wheelL;

	Rigidbody rigidbody;
	float antiRoll = 5000.0f;

	void Start ()
	{
		rigidbody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate ()
	{
		WheelHit hit;
		float travelL = 1.0f;
		float travelR = 1.0f;

		bool groundedL = wheelL.GetGroundHit(out hit);
		if (groundedL)
			travelL = (-wheelL.transform.InverseTransformPoint(hit.point).y - wheelL.radius) / wheelL.suspensionDistance;

		bool groundedR = wheelR.GetGroundHit(out hit);
		if (groundedR)
			travelR = (-wheelR.transform.InverseTransformPoint(hit.point).y - wheelR.radius) / wheelR.suspensionDistance;

		var antiRollForce = (travelL - travelR) * antiRoll;

		if (groundedL)
			rigidbody.AddForceAtPosition(wheelL.transform.up * -antiRollForce,
				wheelL.transform.position); 
		if (groundedR)
			rigidbody.AddForceAtPosition(wheelR.transform.up * antiRollForce,
				wheelR.transform.position); 
	}
}
