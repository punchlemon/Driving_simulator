using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {
    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;
          
    public void ApplyLocalPositionToVisuals(WheelCollider collider) {
        Transform visualWheel = collider.transform.GetChild(0);
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);
        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    public void FixedUpdate() {
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal") / 2;
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float brake2 = maxMotorTorque * Input.GetAxis("Brake2");
        float accel = maxMotorTorque * (1 + Input.GetAxis("Accel")) / 2;
        float brake = maxMotorTorque * (1 + Input.GetAxis("Brake")) / 2;
        float back = maxMotorTorque * (1 + Input.GetAxis("Back")) / 2;
        foreach (AxleInfo axleInfo in axleInfos) {
            Debug.Log(accel);
            Debug.Log(steering);
            if (axleInfo.steering) {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
                axleInfo.leftWheel.brakeTorque = brake;
                axleInfo.rightWheel.brakeTorque = brake;
            }

            if (axleInfo.motor) {
                axleInfo.leftWheel.motorTorque = accel - back;
                axleInfo.rightWheel.motorTorque = accel - back;
                axleInfo.leftWheel.brakeTorque = brake;
                axleInfo.rightWheel.brakeTorque = brake;
            }
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
        }
    }
}

[System.Serializable]
public class AxleInfo {
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; //駆動輪か?
    public bool steering; //ハンドル操作をしたときに角度が変わるか？
}