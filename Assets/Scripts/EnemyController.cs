using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject playerBase;
    GameManager gameManager;
    Rigidbody2D enemyRb;
    Vector2 lookDirection;
    float time = 0;
    [SerializeField] float moveTime = 0.3f;
    [SerializeField] float speed = 3f;
    SpriteRenderer spriteRenderer;
    Material baseMaterial;
    Material newMaterial;
    int _damage = 1;
    int _health = 5;
    public int Health
    {
        get { return _health; }
        set
        {
            ReceiveDamage();
            _health = value;
        }
    }
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
            time = moveTime;
        }
        time -= Time.deltaTime;
        if (Health <= 0)
        {
            gameManager.SetMoney(100);
            Destroy(gameObject);
        }
    }
    void ReceiveDamage()
    {
        spriteRenderer.material = newMaterial;
        Invoke(nameof(ResetToBaseMaterial), 0.3f);
    }
    public void MakeDamage()
    {
        playerBase.GetComponent<PlayerBase>().Health -= _damage;
    }
    void ResetToBaseMaterial()
    {
        spriteRenderer.material = baseMaterial;
    }
}
