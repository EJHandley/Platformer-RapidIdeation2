using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phobot : MonoBehaviour
{
    public int health = 3;
    public float radius = 1f;
    public GameObject thirdHeart;
    public GameObject secondHeart;
    public GameObject firstHeart;

    public Animator animator;

    public void Awake()
    {
        thirdHeart = GameObject.Find("ThirdHeart");
        secondHeart = GameObject.Find("SecondHeart");
        firstHeart = GameObject.Find("FirstHeart");
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health == 2)
        {
            Destroy(thirdHeart);
        }

        if (health == 1)
        {
            Destroy(secondHeart);
        }

        if (health <= 0)
        {
            Destroy(firstHeart);
            Die();
        }
    }

    public void Afraid()
    {
        animator.SetTrigger("OnHit");
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
