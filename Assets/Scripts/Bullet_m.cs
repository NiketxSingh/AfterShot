using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class Bullet_m : MonoBehaviour
{
    Rigidbody2D rb_bullet;
    CapsuleCollider2D bullet_collider;
    GameObject player;
    Shooting_m shooting_m;

    private void Start()
    {
        rb_bullet = GetComponent<Rigidbody2D>();
        bullet_collider = GetComponent<CapsuleCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        shooting_m = player.GetComponent<Shooting_m>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
   
    
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            rb_bullet.bodyType = RigidbodyType2D.Dynamic;
            Destroy(collision.gameObject);
            rb_bullet.velocity = Vector3.zero;
            bullet_collider.isTrigger = false;
            shooting_m.enemyKilled += 1;
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            rb_bullet.bodyType = RigidbodyType2D.Static;

        }
    }

}