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
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class сarMovement : MonoBehaviour
{
    public WheelCollider CWFR_3;
    public WheelCollider CWFL_3;

    public Transform TWFR_3;
    public Transform TWFL_3;

    //public float maxMotorTorque = 15000.0f;
    private float MotoForce_3 = 1500.0f;  // мощность вращения передних колес
    private float SteerForce_3 = 60.0f; // угол поворота передних колес
    public float Radius = 0.98f;       // радиус колеса

    public float BrakeTorque = 3000.0f;  // тормозной крутящий момент
    public float Resistance = 5.0f;      // сопротивление движению

    private Rigidbody carRigidbody;

    void Start()
    {
        // Получаем компонент Rigidbody
        carRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // ввод для угла поворота

        // Ввод для движения вперед/назад (-1 для назад, 0 для стояния, 1 для вперед)
        float v = Input.GetAxis("Vertical");

        // Управление левым и правым моторами в зависимости от ввода
        float leftMotorTorque = 0f;
        float rightMotorTorque = 0f;

        if (h > 0 && v == 0)
        {
            rightMotorTorque = MotoForce_3 / Radius;
        }
        else if (h < 0 && v == 0)
        {
            leftMotorTorque = MotoForce_3 / Radius;
        }
        else if (v > 0 && h == 0)
        {
            rightMotorTorque = leftMotorTorque = MotoForce_3 / Radius;
        }
        else if (v < 0 && h == 0)
        {
            rightMotorTorque = leftMotorTorque = -MotoForce_3 / Radius;
        }
        else if (v > 0 && h > 0)
        {
            rightMotorTorque = 2 * MotoForce_3 / Radius;
            leftMotorTorque = MotoForce_3 / Radius;
        }
        else if (v < 0 && h > 0)
        {
            rightMotorTorque = -2 * MotoForce_3 / Radius;
            leftMotorTorque = -MotoForce_3 / Radius;
        }
        else if (v > 0 && h < 0)
        {
            rightMotorTorque = MotoForce_3 / Radius;
            leftMotorTorque = 2 * MotoForce_3 / Radius;
        }
        else if (v < 0 && h < 0)
        {
            rightMotorTorque = -MotoForce_3 / Radius;
            leftMotorTorque = -2 * MotoForce_3 / Radius;
        }
        else if (v == 0 && h == 0)
        {
            rightMotorTorque = leftMotorTorque = 0f;
        }

        // Применение моторного момента к колесам
        CWFR_3.motorTorque = rightMotorTorque;
        CWFL_3.motorTorque = leftMotorTorque;

        // Установка угла поворота для передних колес
        CWFR_3.steerAngle = h * SteerForce_3;
        CWFL_3.steerAngle = h * SteerForce_3;

        // Торможение при нажатии клавиши пробела
        if (Input.GetKey(KeyCode.Space))
        {
            CWFR_3.brakeTorque = BrakeTorque;
            CWFL_3.brakeTorque = BrakeTorque;
        }
        else
        {
            CWFR_3.brakeTorque = 0f;
            CWFL_3.brakeTorque = 0f;
        }

        // Вращение визуальных трансформаций колес
        TWFR_3.Rotate(CWFR_3.rpm / 60 * 360 * Time.deltaTime, 0.0f, 0.0f);
        TWFL_3.Rotate(CWFL_3.rpm / 60 * 360 * Time.deltaTime, 0.0f, 0.0f);

        // Добавление сопротивления движению
        carRigidbody.drag = Resistance;
    }
}*/