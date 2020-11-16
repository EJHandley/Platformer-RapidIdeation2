using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Vector3 startPosition;

    public int maxHealth = 100;
    public int currentHealth;
    public float spikeAttackRange = 0.5f;
    public float tailAttackRange = 0.5f;
    public float shadowRadius = 1f;

    public BossHealthBar bossHealthBar;

    public GameObject deathEffect;
    public GameObject activationRadius;
    public GameObject youWinUI;

    public Phobot phobot;
    public Transform spikeAttack;
    public Transform tailAttack;
    public Transform shadow;
    public Transform boss;

    public Animator animator;

    public LayerMask playerLayer;
    public LayerMask lightLayer;

    public void Start()
    {
        phobot = GameObject.Find("Phobot").GetComponent<Phobot>();

        currentHealth = maxHealth;
        bossHealthBar.SetMaxHealth(maxHealth);

        startPosition = boss.position;
    }

    void Update()
    {
        Collider2D[] hitPlayerWithSpike = Physics2D.OverlapCircleAll(spikeAttack.position, spikeAttackRange, playerLayer);

        foreach (Collider2D player in hitPlayerWithSpike)
        {
            Attack();
        }

        Collider2D[] hitPlayerWithTail = Physics2D.OverlapCircleAll(tailAttack.position, tailAttackRange, playerLayer);

        foreach (Collider2D player in hitPlayerWithTail)
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
        phobot.TakeDamage(35);
        phobot.Afraid();

        //Move Back
        boss.position = startPosition;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        bossHealthBar.SetHealth(currentHealth);

        boss.position = startPosition;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        YouWin();
        Destroy(gameObject);
        activationRadius.SetActive(false);
    }

    void YouWin()
    {
        youWinUI.SetActive(true);
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(tailAttack.position, tailAttackRange);
        Gizmos.DrawWireSphere(spikeAttack.position, spikeAttackRange);
    }
}
