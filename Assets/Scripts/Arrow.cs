using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    public float damage = 3;
    public float speed = 5f;
    public float lifeTime = 1f;
    public AoEData aoeeffect;
    public GameObject destroyEffect;
    // Start is called before the first frame update
    void Start()
    {
        // Physics.IgnoreCollision(FindGameObjectWithTag("Player").GetComponent<Collider>(), GetComponent<Collider>());
        this.damage = aoeeffect.damage;
        // this.speed = aoeeffect.cooldown;
        this.lifeTime = aoeeffect.lifeTime;
        Invoke("DestroyProjectile", lifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

   
    void DestroyProjectile()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.GetComponent<EnemyHealth>() != null)
        {
            EnemyHealth health = collider.GetComponent<EnemyHealth>();
            health.Damage(damage);
            DestroyProjectile();
        }
    }

}
