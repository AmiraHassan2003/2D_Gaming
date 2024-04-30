using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public Animator animator;
    public Transform attackPoint;
    public LayerMask layerMask;
    public float attackRadius = 1.2f;
    void Start()
    {
        // Assign the Animator component at runtime
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0)){
            TriggerRandomAttack();
        }
    }

    void TriggerRandomAttack()
    {
        int index = Random.Range(0, 3);
        switch (index)
        {
            case 0:
                animator.SetTrigger("Attack1");
                break;
            case 1:
                animator.SetTrigger("Attack2");
                break;
            case 2:
                animator.SetTrigger("Attack3");
                break;
            default:
                Debug.LogError("Invalid index for attack animation.");
                break;
        }
        PerformAttack();
    }

    public void PerformAttack()
    {
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, attackRadius, layerMask);
        if(hit){
            hit.GetComponent<EnemyHealth>().TakeDamage(1);
        }
    }

    public void Attack_Patrol()
    {
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, attackRadius, layerMask);
        if(hit){
            hit.GetComponent<PatrolEnemy>().TakeDamage(1);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint != null)
        {
            Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
        }
    }
}
