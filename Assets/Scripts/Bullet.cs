using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    CollisionAttackType master;
    [SerializeField] float speed = 1;
    Rigidbody2D bulletRb;
    bool setMaster = true;
    Vector2 direction;
    void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
        bulletRb.velocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (!setMaster)
        {
            bulletRb.AddForce(-direction * speed);
        }
        if (transform.position.magnitude > 100)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyController>().Health -= master.attackDamage;
            Destroy(gameObject);
        }
    }
    public void SetParentGameObject(GameObject parent)
    {
        if (setMaster)
        {
            this.master = parent.GetComponent<CollisionAttackType>();
            setMaster = false;
        }
    }
    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }
}
