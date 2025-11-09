using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyBasic : MonoBehaviour
{
    private GameObject player;
    private Vector3 playerPosition;
    private float direction;
    [SerializeField] private float enemySpeed = 2f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        playerPosition = player.transform.position;
        transform.position += new Vector3(playerPosition.x - transform.position.x, 0, 0).normalized * enemySpeed * Time.deltaTime;
        direction = Mathf.Sign((playerPosition - transform.position).x);
        if (direction != 0) {
            transform.localScale = new Vector3(direction,1,1);
        }
    }

}