using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 25;
    public float attackRange = 0.5f;
    public float shadowRadius = 1f;

    public GameObject deathEffect;
    public GameObject activationRadius;

    public Phobot phobot;
    public Transform attackPoint;
    public Transform shadow;
    public Animator animator;

    public LayerMask playerLayer;
    public LayerMask lightLayer;

    public void Awake()
    {
        phobot = GameObject.Find("Phobot").GetComponent<Phobot>();
    }

    void Update()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);

        foreach (Collider2D player in hitPlayer)
        {
            Attack();
        }

        Collider2D[] hitLight = Physics2D.OverlapCircleAll(shadow.position, shadowRadius, lightLayer);

        foreach (Collider2D light in hitLight)
        {
            Die();
        }
    }

    void Attack()
    {
        //Play Animation
        animator.SetTrigger("Attack");

        //Attack Phobot
        phobot.TakeDamage(20);
        phobot.Afraid();

        //Die
        Die();
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
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
