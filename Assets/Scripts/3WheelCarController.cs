using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMovement : MonoBehaviour {
    private float MotoForce_3 = 8000f;  // мощность вращения передних колес

    public WheelCollider CWFR_3;
    public WheelCollider CWFL_3;

    public Transform TWFR_3;
    public Transform TWFL_3;

    void FixedUpdate() {
        float v = Input.GetAxis("Vertical") * MotoForce_3; // ускорение колес

        TWFR_3.Rotate((CWFR_3.rpm*3) / 60 * 360 * Time.deltaTime, 0.0f, 0.0f);
        TWFL_3.Rotate((CWFL_3.rpm*3) / 60 * 360 * Time.deltaTime, 0.0f, 0.0f);

        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.A))
            {
                CWFR_3.motorTorque = 0f;
                CWFL_3.motorTorque = v;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                CWFR_3.motorTorque = v;
                CWFL_3.motorTorque = 0f;
            }
            else
            {
                CWFR_3.motorTorque = v;
                CWFL_3.motorTorque = v;
            }
        }
        else if (Input.GetKey(KeyCode.S)){
            if (Input.GetKey(KeyCode.A))
            {
                CWFR_3.motorTorque = 0f;
                CWFL_3.motorTorque = v;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                CWFR_3.motorTorque = v;
                CWFL_3.motorTorque = 0f;
            }
            else
            {
                CWFR_3.motorTorque = v;
                CWFL_3.motorTorque = v;
            }
        }
        else
        {
            CWFL_3.motorTorque = 0f;
            CWFR_3.motorTorque = 0f;
        }
        if (Input.GetKey(KeyCode.Space)) {
            CWFL_3.brakeTorque = 3000f;
            CWFR_3.brakeTorque = 3000f;
        }
        else {
            CWFL_3.brakeTorque = 0f;
            CWFR_3.brakeTorque = 0f;
        }

    }
}