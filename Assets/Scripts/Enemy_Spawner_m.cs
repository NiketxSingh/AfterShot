using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner_m : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float timer = 5f;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy() {
        while (true) {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(timer);
        }
    }
}