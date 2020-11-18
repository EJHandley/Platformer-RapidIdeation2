using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Transform firePoint;
    public GameObject lanternLight;
    public GameObject energyBarUI;
    public EnergyBar energyBar;

    public int maxEnergy = 60;
    public int currentEnergy = 0;
    public int rechargeValue = 1;

    public void Start()
    {
        energyBarUI.SetActive(true);

        currentEnergy = maxEnergy;
        energyBar.SetMaxEnergy(maxEnergy);

        if (lanternLight.activeSelf == false && currentEnergy <= 60)
        {
            StartCoroutine(RechargeNow());
        }
    }

     void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if (lanternLight.activeSelf == false && currentEnergy >= 20)
            {
                StartCoroutine(TurnOn());
            }
        }
    }

    IEnumerator TurnOn()
    {
        lanternLight.SetActive(true);
        Drain(20);

        yield return new WaitForSeconds(3f);

        lanternLight.SetActive(false);
    }

    public void Drain(int energyDrain)
    {
        currentEnergy -= energyDrain;
        energyBar.SetEnergy(currentEnergy);
    }

    public void Recharge(int energyRecharge)
    {
        currentEnergy += energyRecharge;
        energyBar.SetEnergy(currentEnergy);
    }

    IEnumerator RechargeNow()
    {
        Recharge(1);

        yield return new WaitForSecondsRealtime(1f);

        StartCoroutine(RechargeNow());
    }
}
