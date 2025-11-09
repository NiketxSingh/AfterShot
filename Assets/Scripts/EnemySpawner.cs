using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class EnemySpawner : MonoBehaviour
{
    public float timer = 5f;

    [SerializeField] private List<Transform> enemyPositions = new List<Transform>();
    [SerializeField] private List<GameObject> enemyType = new List<GameObject>();
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            int ch1 = Random.Range(0, enemyPositions.Count);
            int ch2 = Random.Range(0,enemyType.Count);
            Instantiate(enemyType[ch2], enemyPositions[ch1].position, Quaternion.identity);
            yield return new WaitForSeconds(timer);
        }
    }
}