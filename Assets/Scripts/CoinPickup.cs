using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public float radius = 1f;
    public int coinValue = 1;

    public MoonCoinCounter moonCoinCounter;

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
        moonCoinCounter.currentScore += coinValue;
        Destroy(gameObject);
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
