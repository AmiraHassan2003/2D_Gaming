using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth = 5;
    public GameObject explosioPerefab;

    void Update(){
        if(maxHealth <= 0){
            Die();
        }
    }

    public void TakeDamage(int damage){
        if(maxHealth <= 0){
            return;
        }
        maxHealth -= damage;
    }

    void Die(){
        GameObject temp = Instantiate(explosioPerefab, transform.position,  Quaternion.identity);
        Destroy(temp);
        Destroy(this.gameObject);
    }
}
