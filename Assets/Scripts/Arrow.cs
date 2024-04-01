using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    public int damage = 3;
    public float speed = 5f;
    public float lifeTime = 1f;
    public ArrowData arrowData;
    public GameObject destroyEffect;
    // Start is called before the first frame update
    void Start()
    {
        // Physics.IgnoreCollision(FindGameObjectWithTag("Player").GetComponent<Collider>(), GetComponent<Collider>());
        this.damage = arrowData.damage;
        this.speed = arrowData.speed;
        this.lifeTime = arrowData.lifeTime;
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
            health.Damage(damage, false);
            Destroy(gameObject);
        }
    }

}
