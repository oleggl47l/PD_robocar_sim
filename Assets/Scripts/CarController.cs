<<<<<<< HEAD
﻿//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CarController : MonoBehaviour {
//    //// Start is called before the first frame update
//    //void Start()
//    //{

//    //}

//    //// Update is called once per frame
//    //void Update()
//    //{

//    //}

//    public float moveSpeed = 5.0f; // Скорость движения
//    public float rotateSpeed = 90.0f; // Скорость поворота
//    private bool isMovingForward = false;
//    private bool isMovingBackward = false;
//    private bool isRotating = false;
//    private float targetRotation = 0.0f;
//    private float currentRotation = 0.0f;

//    private void Update() {
//        // Проверка нажатых клавиш
//        if (Input.GetKey(KeyCode.W)) {
//            isMovingForward = true;
//            isMovingBackward = false;
//        }
//        else if (Input.GetKey(KeyCode.S)) {
//            isMovingForward = false;
//            isMovingBackward = true;
//        }
//        else {
//            isMovingForward = false;
//            isMovingBackward = false;
//        }

//        // Плавный поворот
//        if (isRotating) {
//            currentRotation = Mathf.MoveTowards(currentRotation, targetRotation, rotateSpeed * Time.deltaTime);
//            transform.rotation = Quaternion.Euler(0.0f, currentRotation, 0.0f);

//            if (Mathf.Approximately(currentRotation, targetRotation)) {
//                isRotating = false;
//            }
//        }

//        // Проверка наличия движения перед попыткой поворота
//        if (!isRotating) {
//            // Поворот вправо
//            if (Input.GetKeyDown(KeyCode.D)) {
//                RotateCar(90.0f);
//            }
//            // Поворот влево
//            else if (Input.GetKeyDown(KeyCode.A)) {
//                RotateCar(-90.0f);
//            }
//        }

//        // Движение вперед или назад
//        if (isMovingForward) {
//            MoveCar(Vector3.forward);
//        }
//        else if (isMovingBackward) {
//            MoveCar(Vector3.back);
//        }
//    }

//    private void MoveCar(Vector3 direction) {
//        // Вычисляем вектор движения
//        Vector3 moveVector = direction * moveSpeed * Time.deltaTime;

//        // Двигаем машину
//        transform.Translate(moveVector);
//    }

//    private void RotateCar(float angle) {
//        targetRotation = currentRotation + angle;
//        isRotating = true;
//    }
//}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMovement : MonoBehaviour {
    private float MotoForce = 500.0f;  // мощность врощения задних колес
    private float SteerForce = 30.0f; // угол поворота передних колес

    public WheelCollider CWFR;
    public WheelCollider CWFL;
    public WheelCollider CWRL;
    public WheelCollider CWRR;

    public Transform TWFR;
    public Transform TWFL;
    public Transform TWRL;
    public Transform TWRR;


    void Update() {
        float v = Input.GetAxis("Vertical") * MotoForce; // ускорение колес
        float h = Input.GetAxis("Horizontal") * SteerForce; // угол поворот передних колес

        TWFR.Rotate(CWFR.rpm / 60 * 360 * Time.deltaTime, 0.0f, 0.0f);
        TWFL.Rotate(CWFL.rpm / 60 * 360 * Time.deltaTime, 0.0f, 0.0f);
        TWRL.Rotate(CWRR.rpm / 60 * 360 * Time.deltaTime, 0.0f, 0.0f);
        TWRR.Rotate(CWRL.rpm / 60 * 360 * Time.deltaTime, 0.0f, 0.0f);

        if (Input.GetKey(KeyCode.Space)) {
            CWFL.brakeTorque = 3000f;
            CWFR.brakeTorque = 3000f;
            CWRL.brakeTorque = 3000f;
            CWRR.brakeTorque = 3000f;
        }
        else {
            CWFL.brakeTorque = 0f;
            CWFR.brakeTorque = 0f;
            CWRL.brakeTorque = 0f;
            CWRR.brakeTorque = 0f;
        }

        CWFR.motorTorque = v;
        CWFL.motorTorque = v;
        CWRL.motorTorque = v;
        CWRR.motorTorque = v;

        CWFR.steerAngle = h;
        CWFL.steerAngle = h;
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    public float moveSpeed = 5.0f; // Скорость движения
    public float rotateSpeed = 90.0f; // Скорость поворота
    private bool isMovingForward = false;
    private bool isMovingBackward = false;
    private bool isRotating = false;
    private float targetRotation = 0.0f;
    private float currentRotation = 0.0f;

    private void Update() {
        // Проверка нажатых клавиш
        if (Input.GetKey(KeyCode.W)) {
            isMovingForward = true;
            isMovingBackward = false;
        }
        else if (Input.GetKey(KeyCode.S)) {
            isMovingForward = false;
            isMovingBackward = true;
        }
        else {
            isMovingForward = false;
            isMovingBackward = false;
        }

        // Плавный поворот
        if (isRotating) {
            currentRotation = Mathf.MoveTowards(currentRotation, targetRotation, rotateSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0.0f, currentRotation, 0.0f);

            if (Mathf.Approximately(currentRotation, targetRotation)) {
                isRotating = false;
            }
        }

        // Проверка наличия движения перед попыткой поворота
        if (!isRotating) {
            // Поворот вправо
            if (Input.GetKeyDown(KeyCode.D)) {
                RotateCar(90.0f);
            }
            // Поворот влево
            else if (Input.GetKeyDown(KeyCode.A)) {
                RotateCar(-90.0f);
            }
        }

        // Движение вперед или назад
        if (isMovingForward) {
            MoveCar(Vector3.forward);
        }
        else if (isMovingBackward) {
            MoveCar(Vector3.back);
        }
    }

    private void MoveCar(Vector3 direction) {
        // Вычисляем вектор движения
        Vector3 moveVector = direction * moveSpeed * Time.deltaTime;

        // Двигаем машину
        transform.Translate(moveVector);
    }

    private void RotateCar(float angle) {
        targetRotation = currentRotation + angle;
        isRotating = true;
>>>>>>> main
    }
}