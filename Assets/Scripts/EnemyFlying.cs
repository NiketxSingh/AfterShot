using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlying : MonoBehaviour {
    [SerializeField] private float enemySpeed = 2f;
    [SerializeField] private float floatAmplitude = 0.5f;
    [SerializeField] private float floatFrequency = 2f;

    [SerializeField] private GameObject bulletPrefab; 
    [SerializeField] private GameObject bulletSpawnPoint; 
    [SerializeField] private float shootInterval = 10f;
    [SerializeField] private float bulletSpeed = 5f;

    private float direction = 1f;
    private float sineOffset;
    private Vector3 startPos;

    void Start() {
        startPos = transform.position;
        sineOffset = Random.Range(0f, 2f * Mathf.PI);

        StartCoroutine(ShootRoutine());
    }

    void Update() {
        float y = Mathf.Sin((Time.time + sineOffset) * floatFrequency) * floatAmplitude;
        transform.position += new Vector3(direction * enemySpeed * Time.deltaTime, y * Time.deltaTime, 0);
        if (direction != 0) {
            transform.localScale = new Vector3(direction, 1, 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.collider.CompareTag("Wall") || collision.collider.CompareTag("Ground")) {
            direction *= -1;
        }
    }

    private IEnumerator ShootRoutine() {
        while (true) {
            yield return new WaitForSeconds(shootInterval);
            Shoot();
        }
    }

    private void Shoot() {
        if (bulletPrefab == null) return;

        Vector3 spawnPos = bulletSpawnPoint ? bulletSpawnPoint.transform.position : transform.position;

        GameObject bullet = Instantiate(bulletPrefab, spawnPos, Quaternion.identity);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null) {
            rb.velocity = Vector2.down * bulletSpeed;
        }

    }
}
