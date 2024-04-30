using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    private int score = 0;
    private void OnTriggerEnter2D(Collider2D coll){
        if(coll.gameObject.CompareTag("goal")){
            Destroy(coll.gameObject);
            score++;
        }
    }
}
