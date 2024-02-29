using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class middleScript : MonoBehaviour
{

    public CarMovement carMovementScript; // Ссылка на объект класса carMovement

    void Start() {
        // Получаем ссылку на компонент СarMovement при старте
        carMovementScript = GetComponent<CarMovement>();
    }

    private void Update() {
        float lf = 2000f;
        float rf = 2000f;
        int t = 2;
        if (carMovementScript.isMoving || Input.anyKeyDown) {
            carMovementScript.Movement(lf, rf, t);
        }
    }
    
}
