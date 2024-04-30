using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth = 5;
    public Slider healthBar;

    void Start(){
        healthBar.maxValue = maxHealth;
    }

    void Update(){
        if(maxHealth <= 0){
            Die();
        }
        healthBar.value = maxHealth;
    }
    public void TakeDamage(int damage){
        if(maxHealth <= 0){
            return;
        }
        maxHealth -= damage;
    }

    void Die(){
        Destroy(this.gameObject);
    }
}
