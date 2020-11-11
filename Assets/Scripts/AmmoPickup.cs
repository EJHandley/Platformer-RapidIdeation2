using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public float radius = 1f;

    public GameObject thirdEnergy;
    public GameObject secondEnergy;
    public GameObject firstEnergy;

    public Transform phobotPosition;

    void Update()
    {
        float phobotDistance = Vector2.Distance(phobotPosition.position, transform.position);
        if (phobotDistance <= radius)
        {
            Pickup();
        }
    }

    public void Pickup()
    {
        if (firstEnergy.activeSelf == false && secondEnergy.activeSelf == false && thirdEnergy.activeSelf == false)
        {
            firstEnergy.SetActive(true);
            Destroy(gameObject);
        }
        else if (firstEnergy.activeSelf == true && secondEnergy.activeSelf == false && thirdEnergy.activeSelf == false)
        {
            secondEnergy.SetActive(true);
            Destroy(gameObject);
        }
        else if (firstEnergy.activeSelf == true && secondEnergy.activeSelf == true && thirdEnergy.activeSelf == false)
        {
            thirdEnergy.SetActive(true);
            Destroy(gameObject);
        }
        else if (firstEnergy.activeSelf == true && secondEnergy.activeSelf == true && thirdEnergy.activeSelf == true)
        {
            return;
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
