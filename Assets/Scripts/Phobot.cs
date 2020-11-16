using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phobot : MonoBehaviour
{
    public int maxFear = 100;
    public int currentFear;

    public FearBar fearBar;

    public Animator animator;

    public GameObject youDiedUI;

    public void Start()
    {
        currentFear = 0;
    }

    public void TakeDamage(int damage)
    {
        currentFear += damage;

        fearBar.SetFear(currentFear);

        if (currentFear >= maxFear)
        {
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
        YouDied();
    }

    void YouDied()
    {
        youDiedUI.SetActive(true);
    }
}
