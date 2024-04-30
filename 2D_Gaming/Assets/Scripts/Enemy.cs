using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public float attackRange = 5f;
    public float speed = 2f;
    public float retrieveDistance = 3f;
    private bool facingLeft = true;
    private Animator animator;

    private Vector2 currentDirection = Vector2.left;
    private Rigidbody2D rigid;
    public float timeInterval = 2f;
    public float SpeedX = 5f;
    private float nextDirectionChangeTime;

    
    void Start()
    {
        animator = this.GetComponent<Animator>();
        rigid = this.GetComponent<Rigidbody2D>();
        nextDirectionChangeTime = Time.time + timeInterval;

    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position , player.position) <= attackRange){
            if(Vector2.Distance(transform.position , player.position) > retrieveDistance){
                animator.SetBool("isRange" , true);
                animator.SetBool("Attack" , false);
                transform.position = Vector2.MoveTowards(transform.position , player.position , speed * Time.deltaTime);
            }
            else{
                animator.SetBool("Attack" , true);
            }
        }
        else{
            animator.SetBool("isRange" , false);
            if(Time.time >= nextDirectionChangeTime){
                currentDirection = -currentDirection;
                Vector2 currentScale = gameObject.transform.localScale;
                currentScale.x *= -1;
                gameObject.transform.localScale = currentScale;
                nextDirectionChangeTime = Time.time + timeInterval;
            }
            Vector2 movement = new Vector2(currentDirection.x * SpeedX , rigid.velocity.y);
            rigid.velocity = movement;
            
        }
        SetFlip();

    }

    void SetFlip(){
        if(player.position.x > transform.position.x && facingLeft){
            transform.eulerAngles = new Vector3(0, -180, 0);
            facingLeft = false;
        }
        else if(player.position.x < transform.position.x && !facingLeft){
            transform.eulerAngles = new Vector3(0f , 0f , 0f);
            facingLeft = true;
        }
    }

}
