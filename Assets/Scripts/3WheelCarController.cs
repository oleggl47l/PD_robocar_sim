using System.Threading.Tasks;
using UnityEngine;

public class carMovement : MonoBehaviour {
    private bool isMoving = false;

    public WheelCollider CWFR_3;
    public WheelCollider CWFL_3;

    public Transform TWFR_3;
    public Transform TWFL_3;

    void Movement(float lf, float rf, int t)
    {
        float v1 = Input.GetAxis("Vertical") * lf;
        float v2 = Input.GetAxis("Vertical") * rf;
        float h1 = Input.GetAxis("Horizontal")*lf;
        float h2 = Input.GetAxis("Horizontal")*rf;


        TWFR_3.Rotate((CWFR_3.rpm * 3) / 60 * 360 * Time.deltaTime, 0.0f, 0.0f);
        TWFL_3.Rotate((CWFL_3.rpm * 3) / 60 * 360 * Time.deltaTime, 0.0f, 0.0f);



    }

    void Update()
    {
        float lf = 5000f;
        float rf = 5000f;
        int t = 3;
        if (isMoving || Input.anyKeyDown)
        {
            Movement(lf, rf, t);
        }
    }
}