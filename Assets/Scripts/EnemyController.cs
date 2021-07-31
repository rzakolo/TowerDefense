using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject playerBase;
    Rigidbody2D enemyRb;
    Vector2 lookDirection;
    float time = 0;
    [SerializeField] float moveTime = 0.3f;
    [SerializeField] float speed = 3f;
    SpriteRenderer spriteRenderer;
    Material baseMaterial;
    Material newMaterial;
    int _health = 5;
    public int Health
    {
        get { return _health; }
        set
        {
            TakeDamage();
            _health = value;
        }
    }
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        baseMaterial = spriteRenderer.material;
        newMaterial = Resources.Load("enemyBlink", typeof(Material)) as Material;
        playerBase = GameObject.Find("Base");
        enemyRb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (time < 0)
        {
            lookDirection = (playerBase.transform.position - transform.position).normalized;
            enemyRb.AddForce(lookDirection * speed);
            enemyRb.velocity = Vector2.zero;
            //transform.position += playerBase.transform.position * Time.deltaTime;
            time = moveTime;
        }
        time -= Time.deltaTime;
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
    void TakeDamage()
    {
        spriteRenderer.material = newMaterial;
        Invoke(nameof(ResetToBaseMaterial), 0.3f);
    }
    void ResetToBaseMaterial()
    {
        spriteRenderer.material = baseMaterial;
    }
}
