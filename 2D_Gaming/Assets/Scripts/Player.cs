using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigid;
    private BoxCollider2D box;
    private Animator animator;
    [SerializeField]private float speedOfX = 7f;
    private float jumpValue = 10f;
    [SerializeField]private LayerMask ground;

    bool facingRight = true;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float lr = Input.GetAxisRaw("Horizontal");
        rigid.velocity = new Vector2(speedOfX* lr , rigid.velocity.y);
        if(Input.GetButtonDown("Jump") && IsGround()){
            rigid.velocity = new Vector2(rigid.velocity.x , jumpValue);
        }
        if(lr > 0 && !facingRight){
            Flip();
        }
        if(lr < 0 && facingRight){
            Flip();
        }
        if(lr != 0){
            animator.SetBool("Run" , true);
        }
        else{
            animator.SetBool("Run" , false);
        }
        JumpAnimation();
    
    }

    void Flip(){
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }

    private bool IsGround(){
        return Physics2D.BoxCast(box.bounds.center , box.bounds.size , 0f , Vector2.down , 0.1f , ground);
    }

    private void JumpAnimation(){
        int index = Random.Range(0,2);
        if(!IsGround()){
            switch (index)
            {
                case 0:
                    animator.SetBool("Jump" , true);
                    break;
                case 1:
                    animator.SetBool("DoubleJump" , true);
                    break;
                default:
                    Debug.LogError("Invalid index for Jump animation.");
                    break;
            }
        }
        else{
            animator.SetBool("Jump" , false);
            animator.SetBool("DoubleJump" , false);
        }
    }
}
