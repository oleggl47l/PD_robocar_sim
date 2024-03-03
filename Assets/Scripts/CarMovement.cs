using System.Threading.Tasks;
using UnityEngine;

public class CarMovement : MonoBehaviour {
    public bool w = false;
    public bool s = false;
    public bool a = false;
    public bool d = false;
    public float starttime;
    public WheelCollider CWFR_3;
    public WheelCollider CWFL_3;

    public Transform TWFR_3;
    public Transform TWFL_3;

    public void Movement(float lf, float rf, int timedelta) {
        float v1 = lf;
        float v2 = rf;


        TWFR_3.Rotate((CWFR_3.rpm * 3) / 60 * 360 * Time.deltaTime, 0.0f, 0.0f);
        TWFL_3.Rotate((CWFL_3.rpm * 3) / 60 * 360 * Time.deltaTime, 0.0f, 0.0f);

        if (Input.GetKeyDown(KeyCode.W))
        {
            s = false;
            a = false;
            d = false;
            w = true;
            starttime = Time.unscaledTime;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            w = false;
            a = false;
            d = false;
            s = true;
            starttime = Time.unscaledTime;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            w = false;
            s = false;
            d = false;
            a = true;
            starttime = Time.unscaledTime;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            w = false;
            s = false;
            a = false;
            d = true;
            starttime = Time.unscaledTime;
        }
        if (Time.unscaledTime - starttime <= timedelta / 1.5 && w == true)
        {
            CWFR_3.motorTorque = v2;
            CWFL_3.motorTorque = v1;
        }
        else if (Time.unscaledTime - starttime <= timedelta / 1.5&& s == true)
        {
            CWFR_3.motorTorque = -v2;
            CWFL_3.motorTorque = -v1;
        }
        else if (Time.unscaledTime - starttime <= timedelta / 1.1 && a == true)
        {
            CWFR_3.motorTorque = -v2;
            CWFL_3.motorTorque = v1;
        }
        else if (Time.unscaledTime - starttime <= timedelta / 1.1 && d == true)
        {
            CWFR_3.motorTorque = v2;
            CWFL_3.motorTorque = -v1;
        } // -> stopping
        else if (Time.unscaledTime - starttime <= timedelta && w == true)
        {
            CWFR_3.motorTorque = -v2;
            CWFL_3.motorTorque = -v1;
        }
        else if (Time.unscaledTime - starttime <= timedelta && s == true)
        {
            CWFR_3.motorTorque = v2;
            CWFL_3.motorTorque = v1;
        }
        else if (Time.unscaledTime - starttime <= timedelta && a == true)
        {
            CWFR_3.motorTorque = v2;
            CWFL_3.motorTorque = -v1;
        }
        else if (Time.unscaledTime - starttime <= timedelta && d == true)
        {
            CWFR_3.motorTorque = -v2;
            CWFL_3.motorTorque = v1;
        }
        else
        {
            w = false;
            s = false;
            a = false;
            d = false;
            CWFR_3.motorTorque = 0f;
            CWFL_3.motorTorque = 0f;
        }
    }
}