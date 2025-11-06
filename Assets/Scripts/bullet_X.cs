using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_X : MonoBehaviour
{
    Rigidbody2D rb_bullet;
    CapsuleCollider2D bullet_collider;

    private void Start()
    {
        rb_bullet = GetComponent<Rigidbody2D>();
        bullet_collider = GetComponent<CapsuleCollider2D>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
   
    
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            rb_bullet.bodyType = RigidbodyType2D.Dynamic;
            Destroy(collision.gameObject);
            rb_bullet.velocity = Vector3.zero;
            bullet_collider.isTrigger = false;
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