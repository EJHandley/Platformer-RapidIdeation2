using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternPickup : MonoBehaviour
{
    public float radius = 1f;

    public Transform phobotPosition;
    public GameObject phobotLantern;

    void Update()
    {
        float phobotDistance = Vector2.Distance(phobotPosition.position, transform.position);
        if (phobotDistance <= radius)
        {
            Pickup();
        }
    }

    void Pickup()
    {
        Destroy(gameObject);
        phobotLantern.SetActive(true);
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
