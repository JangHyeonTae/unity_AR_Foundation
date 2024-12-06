using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakPlace : MonoBehaviour
{
    [SerializeField] private float breakTime = 2f;
    private Animator animator;
    private bool hasAnimator;

    void Start()
    {
        hasAnimator = TryGetComponent(out animator);
        if (hasAnimator)
        {
            animator.applyRootMotion = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (hasAnimator)
            {
                animator.SetTrigger("Break");
            }

            Destroy(this.gameObject, breakTime);
        }
    }

}

