using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightSensor : MonoBehaviour
{
    public Rigidbody robotBody;

    // Start is called before the first frame update
    void Start()
    {
        FixedJoint fixedJoint = gameObject.AddComponent<FixedJoint>();
        fixedJoint.connectedBody = robotBody;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        // Debug.DrawRay(transform.position, transform.forward * 10, Color.red);

        Ray ray = new Ray(transform.position, -transform.up);

        // Длина луча
        float rayLength = 0.83f;

        if (Physics.Raycast(ray, out RaycastHit hit, rayLength))
        {
            Debug.DrawRay(transform.position, -transform.up * rayLength, Color.green);
            Color color_ray = hit.collider.gameObject.GetComponent<Renderer>().material.color;

            // Преобразовываем цвет в формат от 0 до 255
            int r = Mathf.RoundToInt(color_ray.r * 255);
            int g = Mathf.RoundToInt(color_ray.g * 255);
            int b = Mathf.RoundToInt(color_ray.b * 255);

            Debug.Log("Текущий цвет поверхности: " + r + " " + b + " " + g);
        }
        else
        {
            Debug.DrawRay(transform.position, -transform.up * rayLength, Color.red);

        }

    }
}
