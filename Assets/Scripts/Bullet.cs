using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    CollisionAttackType master;
    [SerializeField] float speed = 1;
    Rigidbody2D bulletRb;
    Vector2 direction;
    private int attackDamage;
    void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
        bulletRb.velocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {

        bulletRb.AddForce(-direction * speed);
        if (transform.position.magnitude > 100)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyController>().Health -= attackDamage;
            Destroy(gameObject);
        }
    }
    public void SetDamage(int damage)
    {
        attackDamage = damage;
    }


    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }
}
