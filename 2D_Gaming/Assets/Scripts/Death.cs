using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    private Rigidbody2D rigid;
    void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.K)){
            Die();
        }
    }

    private void Die(){
        rigid.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("Death");

    }

    void restartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
