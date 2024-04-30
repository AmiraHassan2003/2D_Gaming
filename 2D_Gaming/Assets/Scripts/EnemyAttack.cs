using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform attackPoint;
    public LayerMask layerMask;
    public float attackRadius = 1.2f;

    public void Attack(){
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, attackRadius, layerMask);
        if(hit){
            hit.GetComponent<PlayerHealth>().TakeDamage(1);
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
