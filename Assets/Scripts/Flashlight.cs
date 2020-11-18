using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Transform firePoint;
    public GameObject lanternLight;

     void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if (lanternLight.activeSelf == false)
            {
                TurnOn();
            }
            else if (lanternLight.activeSelf == true)
            {
                TurnOff();
            }
            Debug.Log("You Pressed E");
        }
    }

    void TurnOn()
    {
        lanternLight.SetActive(true);
    }

    void TurnOff()
    {
        lanternLight.SetActive(false);
    }
}
