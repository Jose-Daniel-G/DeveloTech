using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMushroom : MonoBehaviour
{   
    private Animator animator;

    private void Start(){
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (ContactPoint2D point in other.contacts)
            {
                if (point.normal.y <= -0.9)
                {
                    animator.SetTrigger("Golpe");
                    other.gameObject.GetComponent<MovementPlayer>().Bounce();
                }
            }
        }
    }
}
