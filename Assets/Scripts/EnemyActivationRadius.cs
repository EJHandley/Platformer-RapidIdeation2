using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActivationRadius : MonoBehaviour
{
    public Transform phobotPosition;
    public GameObject enemy;

    public float radius = 1f;

    public void Awake()
    {
        phobotPosition = GameObject.Find("Phobot").transform;
    }

    void Update()
    {
        float phobotDistance = Vector2.Distance(phobotPosition.position, transform.position);
        if (phobotDistance <= radius)
        {
            EnemyActivated();
        }
    }

    public void EnemyActivated()
    {
        enemy.SetActive(true);
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
