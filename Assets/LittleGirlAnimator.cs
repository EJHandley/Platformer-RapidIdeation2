using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleGirlAnimator : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;

    const float movementFloatTime = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("speedPercent", rb.velocity.x, movementFloatTime, Time.deltaTime);
    }
}
