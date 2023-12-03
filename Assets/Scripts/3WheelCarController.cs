using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMovement : MonoBehaviour {
    private float MotoForce_3 = 1500.0f;  // мощность вращения передних колес
    private float SteerForce_3 = 60.0f; // угол поворота передних колес

    public WheelCollider CWFR_3;
    public WheelCollider CWFL_3;
    public WheelCollider CWR_3;

    public Transform TWFR_3;
    public Transform TWFL_3;
    public Transform TWR_3;

    void Update() {
        float v = Input.GetAxis("Vertical") * MotoForce_3; // ускорение колес
        float h = Input.GetAxis("Horizontal") * SteerForce_3; // угол поворотaw передних колес

        TWFR_3.Rotate(CWFR_3.rpm / 60 * 360 * Time.deltaTime, 0.0f, 0.0f);
        TWFL_3.Rotate(CWFL_3.rpm / 60 * 360 * Time.deltaTime, 0.0f, 0.0f);

        if (Input.GetKey(KeyCode.Space)) {
            CWFL_3.brakeTorque = 3000f;
            CWFR_3.brakeTorque = 3000f;
            CWR_3.brakeTorque = 3000f;
        }
        else {
            CWFL_3.brakeTorque = 0f;
            CWFR_3.brakeTorque = 0f;
            CWR_3.brakeTorque = 0f;
        }

        CWFR_3.motorTorque = v;
        CWFL_3.motorTorque = v;

        CWFR_3.steerAngle = h;
        CWFL_3.steerAngle = h;
    }
}