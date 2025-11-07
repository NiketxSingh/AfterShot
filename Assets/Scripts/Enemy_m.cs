using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy_m : MonoBehaviour
{
    private GameObject player;
    private Vector3 playerLocation;
    private Rigidbody2D rb;
    [SerializeField] private float enemySpeed = 2f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();   
    }

    void Update()
    {
        playerLocation = player.transform.position;
        transform.position += enemySpeed * Time.deltaTime * new Vector3(playerLocation.x - transform.position.x,0,0).normalized;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.collider.CompareTag("Player")) {
            Time.timeScale = 0f;
            Debug.Log("Game Over");
        }
    }
}
