using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 1;
    public float radius = 1f;

    public GameObject deathEffect;
    public GameObject activationRadius;

    public Phobot phobot;
    public Transform phobotPosition;

    public void Awake()
    {
        phobotPosition = GameObject.Find("Phobot").transform;
        phobot = GameObject.Find("Phobot").GetComponent<Phobot>();
    }

    void Update()
    {
        float phobotDistance = Vector2.Distance(phobotPosition.position, transform.position);
        if (phobotDistance <= radius)
        {
            Attack();
        }
    }

    void Attack()
    {
        phobot.TakeDamage(1);
        phobot.Afraid();
        Destroy(gameObject);
        activationRadius.SetActive(false);
    }

    public void TakeDamage (int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        activationRadius.SetActive(false);
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
