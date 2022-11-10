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
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float brake2 = maxMotorTorque * Input.GetAxis("Brake2");
        float accel = maxMotorTorque * (1 - (Input.GetAxis("Accel") + 1) / 2);
        float brake = maxMotorTorque * (1 - (Input.GetAxis("Brake") + 1) / 2);
        foreach (AxleInfo axleInfo in axleInfos) {
            if (axleInfo.steering) {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
                axleInfo.leftWheel.brakeTorque = brake * 8;
                axleInfo.rightWheel.brakeTorque = brake * 8;
                if (accel == 500 & brake == 500)
                {
                    accel = motor;
                    brake = brake2;
                    axleInfo.leftWheel.motorTorque = accel;
                    axleInfo.rightWheel.motorTorque = accel;
                    axleInfo.leftWheel.brakeTorque = brake * 8;
                    axleInfo.rightWheel.brakeTorque = brake * 8;
                }
            }

            if (axleInfo.motor) {
                axleInfo.leftWheel.motorTorque = accel;
                axleInfo.rightWheel.motorTorque = accel;
                axleInfo.leftWheel.brakeTorque = brake * 2;
                axleInfo.rightWheel.brakeTorque = brake * 2;
                if(accel == 500 & brake == 500)
                {
                    accel = motor;
                    brake = brake2;
                    axleInfo.leftWheel.motorTorque = accel;
                    axleInfo.rightWheel.motorTorque = accel;
                    axleInfo.leftWheel.brakeTorque = brake * 2;
                    axleInfo.rightWheel.brakeTorque = brake * 2;
                }
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