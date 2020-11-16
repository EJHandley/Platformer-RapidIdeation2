using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Transform firePoint;
    public int damage = 25;

    public GameObject thirdEnergy;
    public GameObject secondEnergy;
    public GameObject firstEnergy;

     void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(thirdEnergy.activeSelf == true)
            {
                thirdEnergy.SetActive(false);
                Shoot();
            }
            else if(thirdEnergy.activeSelf == false && secondEnergy.activeSelf == true)
            {
                secondEnergy.SetActive(false);
                Shoot();
            }
            else if(thirdEnergy.activeSelf == false && secondEnergy.activeSelf == false && firstEnergy.activeSelf == true)
            {
                firstEnergy.SetActive(false);
                Shoot();
            }
        }
    }

    void Shoot ()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

        if (hitInfo)
        {
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            Boss boss = hitInfo.transform.GetComponent<Boss>();
            {
                boss.TakeDamage(damage);
            }
        }
    }
}
