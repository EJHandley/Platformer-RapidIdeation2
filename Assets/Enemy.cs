using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 1;
    public float radius = 1f;

    public GameObject deathEffect;
    public Phobot phobotHit;
    public Transform phobotPosition;

    public void Awake()
    {
        phobotPosition = GameObject.Find("Phobot").transform;
        phobotHit = GameObject.Find("Phobot").GetComponent<Phobot>();
    }

    void Update()
    {
        float phobotDistance = Vector2.Distance(phobotPosition.position, transform.position);
        if (phobotDistance <= radius)
        {
            phobotHit.TakeDamage(1);
            Destroy(gameObject);
        }
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
    }

    public void HitPhobot ()
    {

    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
