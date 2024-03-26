using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BatteryPicker : MonoBehaviour
{
    public TMP_Text batteryText;
    private float batteries = 0;

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Battery")
        {
            batteries++;
            batteryText.text = batteries.ToString();
            Destroy(coll.gameObject);
        }
    }
}
