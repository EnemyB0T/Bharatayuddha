using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public int damage = 3;

    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.GetComponent<EnemyHealth>() != null)
        {
            EnemyHealth health = collider.GetComponent<EnemyHealth>();
            health.Damage(damage, true);
            Enemy enemy = collider.GetComponent<Enemy>();
            enemy.Hit();
        }
    }
    
}
