using System.Collections;
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
    }
}