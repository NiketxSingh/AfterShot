using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class BombBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public float radius = 5f;
    private GameObject player;

    private Shooting shooting;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        shooting = player.GetComponent<Shooting>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radius);
            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].gameObject.CompareTag("Enemy"))
                {
                    Destroy(hits[i].gameObject);
                    shooting.enemyKilled += 1;
                    
                }
            }
            Destroy(gameObject);

        }
    }
}