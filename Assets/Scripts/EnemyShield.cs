using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyShield : MonoBehaviour {
    private GameObject player;
    private Vector3 playerPosition;
    [SerializeField] private float enemySpeed = 2f;
    private Rigidbody2D rb_enemy;
    private float enemyJumpSpeed = 5f;

    private float direction;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        rb_enemy = GetComponent<Rigidbody2D>();
    }

    void Update() {
        playerPosition = player.transform.position;
        transform.position += new Vector3(playerPosition.x - transform.position.x, 0, 0).normalized * enemySpeed * Time.deltaTime;
        direction = Mathf.Sign((playerPosition - transform.position).x);
        if (direction != 0) {
            transform.localScale = new Vector3(direction, 1, 1);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.CompareTag("Spike")) {
            Jump();
        }
    }

    public void Jump() {
        rb_enemy.velocity = new Vector2(rb_enemy.velocity.x, enemyJumpSpeed);
    }
}