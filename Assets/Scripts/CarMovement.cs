using System.Threading.Tasks;
using UnityEngine;

public class CarMovement : MonoBehaviour {
    public bool isMoving = false;
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

        if (Input.GetKeyDown(KeyCode.W)) {
            w = true;
            isMoving = true;
            starttime = Time.time;
        }
        else if (Input.GetKeyDown(KeyCode.S)) {
            s = true;
            isMoving = true;
            starttime = Time.time;
        }
        else if (Input.GetKeyDown(KeyCode.A)) {
            a = true;
            isMoving = true;
            starttime = Time.time;
        }
        else if (Input.GetKeyDown(KeyCode.D)) {
            d = true;
            isMoving = true;
            starttime = Time.time;
        }

        if (isMoving && Time.time - starttime <= timedelta && w == true) {
            CWFR_3.motorTorque = v2;
            CWFL_3.motorTorque = v1;
        }
        else if (isMoving && Time.time - starttime <= timedelta && s == true) {
            CWFR_3.motorTorque = -v2;
            CWFL_3.motorTorque = -v1;
        }
        else if (isMoving && Time.time - starttime <= timedelta && a == true) {
            CWFR_3.motorTorque = 0f;
            CWFL_3.motorTorque = v1;
        }
        else if (isMoving && Time.time - starttime <= timedelta && d == true) {
            CWFR_3.motorTorque = v2;
            CWFL_3.motorTorque = 0f;
        }
        else {
            isMoving = false;
            w = false;
            s = false;
            a = false;
            d = false;
            CWFR_3.motorTorque = 0f;
            CWFL_3.motorTorque = 0f;
        }
    }
}