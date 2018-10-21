using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

	public List<AxleInfo> axleInfos; // the information about each individual axle
	public float maxMotorTorque; // maximum torque the motor can apply to wheel
	public float maxSteeringAngle; // maximum steer angle the wheel can have
	public bool constrainZAxis;

	Rigidbody rigidbody;

	public void Start()
	{
		rigidbody = GetComponent<Rigidbody> ();
		rigidbody.centerOfMass = new Vector3 (0f, -0.5f, 1f);
	}

	public void FixedUpdate()
	{
		float motor = maxMotorTorque * Input.GetAxis("Vertical");
		float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

		foreach (AxleInfo axleInfo in axleInfos) {
			if (axleInfo.steering) {
				axleInfo.leftWheel.steerAngle = steering;
				axleInfo.rightWheel.steerAngle = steering;
			}
			if (axleInfo.motor) {
				axleInfo.leftWheel.motorTorque = motor;
				axleInfo.rightWheel.motorTorque = motor;
			}
		}

		if (constrainZAxis) 
		{
			float angleZ = transform.eulerAngles.z;
			if (angleZ > 10f && angleZ < 170f) {
				angleZ = 10f;
			} else if (angleZ < 350f && angleZ >= 170f) {
				angleZ = 350f;
			}

			transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, angleZ);
		}
	
	}

}

[System.Serializable]
public class AxleInfo {
	public WheelCollider leftWheel;
	public WheelCollider rightWheel;
	public bool motor; // is this wheel attached to motor?
	public bool steering; // does this wheel apply steer angle?
}
