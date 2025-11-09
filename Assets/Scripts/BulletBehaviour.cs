using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class BulletBehaviour : MonoBehaviour
{
    private Rigidbody2D rb_bullet;
    private CapsuleCollider2D bullet_collider;
    private GameObject player;
    private Shooting shooting;

    private void Start()
    {
        rb_bullet = GetComponent<Rigidbody2D>();
        bullet_collider = GetComponent<CapsuleCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        shooting = player.GetComponent<Shooting>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
   
    
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Shield"))
        {
            rb_bullet.bodyType = RigidbodyType2D.Dynamic;
            rb_bullet.velocity = Vector3.zero;
            bullet_collider.isTrigger = false;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            rb_bullet.bodyType = RigidbodyType2D.Dynamic;
            rb_bullet.velocity = Vector3.zero;
            bullet_collider.isTrigger = false;
            Destroy(collision.gameObject);
            shooting.enemyKilled += 1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            rb_bullet.bodyType = RigidbodyType2D.Static;
            gameObject.tag = "Spike";
            gameObject.layer = 8;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);

        }
    }

}