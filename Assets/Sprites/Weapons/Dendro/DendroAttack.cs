using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DendroAttack : MonoBehaviour
{
    public float damage = 2f;
    public int element = 2; //Dendro

    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<EnemyHealth>() != null)
        {
            EnemyHealth health = collider.GetComponent<EnemyHealth>();
            health.Damage(damage, element);
            Enemy enemy = collider.GetComponent<Enemy>();
            enemy.Hit();
        }
    }
}
