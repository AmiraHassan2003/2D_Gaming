using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    public float speed = 3.97f;
    public Transform detectPoint;
    public LayerMask layerMask;
    public float distance = 1f;
    private bool facingRight = true;
    public float attackRange = 3f;
    private Animator animator;
    private Transform player;
    public Transform attackPoint;
    public LayerMask layer;
    public float attackRadius = 1.5f;
    public int maxHealth = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        DetectingGround();
        if(Vector2.Distance(player.position, transform.position) <= attackRange){
            animator.SetBool("inRange" , true);
        }
        else{
            animator.SetBool("inRange" , false);
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

    }

    public void TakeDamage(int damage){
        if(maxHealth <=0 ){
            return;
        }
        maxHealth -= damage;
    }


    public void Attack(){
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, attackRadius, layer);
        if(hit){
            hit.GetComponent<PlayerHealth>().TakeDamage(1);
        }
    }

    void DetectingGround(){
       RaycastHit2D hit = Physics2D.Raycast(detectPoint.position , Vector2.down , distance, layerMask);
       if(hit == false){
            if(facingRight){
                transform.eulerAngles = new Vector3(0 , -180, 0);
                facingRight = false;
            }
            else if(facingRight == false){
                transform.eulerAngles = new Vector3(0,0,0);
                facingRight = true;
            }
       }
    }
    void OnDrawGizmosSelected(){
        if(detectPoint == null){return;}
        Gizmos.DrawRay(detectPoint.position, Vector2.down * distance);
        if(attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }

}
