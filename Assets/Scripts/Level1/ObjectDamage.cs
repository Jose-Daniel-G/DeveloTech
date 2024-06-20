using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDamage : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter2D(Collider2D collider){
        if (collider.TryGetComponent(out PlayerLife playerLife)){
            playerLife.Damage(damage);
        }
    }
    // private void OnTriggerEnter2D(Collider2D collider){
    //     if (collider.TryGetComponent(out PlayerCombat playerCombat)){
    //         playerCombat.Damage(damage);
    //     }
    // }
}
