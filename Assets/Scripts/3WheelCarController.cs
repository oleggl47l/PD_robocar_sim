using UnityEngine;

public class carMovement : MonoBehaviour {
    private float MotoForce_3 = 6000f;  // мощность вращения передних колес

    public WheelCollider CWFR_3;
    public WheelCollider CWFL_3;

    public Transform TWFR_3;
    public Transform TWFL_3;

    void Movement(float lf, float rf, float t)
    {
        float v1 = Input.GetAxis("Vertical") * lf;
        float v2 = Input.GetAxis("Vertical") * rf;
        float h1 = Input.GetAxis("Horizontal")*lf;
        float h2 = Input.GetAxis("Horizontal")*rf;


        TWFR_3.Rotate((CWFR_3.rpm * 3) / 60 * 360 * Time.deltaTime, 0.0f, 0.0f);
        TWFL_3.Rotate((CWFL_3.rpm * 3) / 60 * 360 * Time.deltaTime, 0.0f, 0.0f);

        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.A))
            {
                CWFR_3.motorTorque = 0f;
                CWFL_3.motorTorque = v1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                CWFR_3.motorTorque = v2;
                CWFL_3.motorTorque = 0f;
            }
            else
            {
                CWFR_3.motorTorque = v2;
                CWFL_3.motorTorque = v1;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.A))
            {
                CWFR_3.motorTorque = 0f;
                CWFL_3.motorTorque = v1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                CWFR_3.motorTorque = v2;
                CWFL_3.motorTorque = 0f;
            }
            else
            {
                CWFR_3.motorTorque = v2;
                CWFL_3.motorTorque = v1;
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            CWFR_3.motorTorque = 0f;
            CWFL_3.motorTorque = -h1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            CWFL_3.motorTorque = 0f;
            CWFR_3.motorTorque = h2;
        }
        else
        {
            CWFL_3.motorTorque = 0f;
            CWFR_3.motorTorque = 0f;
        }
    }

    void FixedUpdate()
    {
        float lf = 5000f;
        float rf = 5000f;
        float t = 3;
        Movement(lf, rf, t);
    }
}