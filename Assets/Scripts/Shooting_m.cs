using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_m : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bombPrefab;
    public Transform shootPoint;
    public float bulletspeed = 10f;
    private Vector2 direction;
    private bool canShoot = false;
    public int enemyKilled = 0;
    public bool bombMode = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            direction = Vector2.right;
            canShoot = true;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            direction = Vector2.left;
            canShoot = true;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            direction = Vector2.up;
            canShoot = true;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            direction = Vector2.down;
            canShoot = true;
        }
        if (Input.GetKeyDown(KeyCode.E) && enemyKilled >= 5)
        {
            bombMode = !bombMode;
        }
        if (direction != Vector2.zero && canShoot && bombMode == true)
        {
            enemyKilled = 0;
            GameObject bomb = Instantiate(bombPrefab, shootPoint.position, Quaternion.identity);
            bomb.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;
            canShoot = false;
        }
        if (direction != Vector2.zero && canShoot && bombMode == false)
        {
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;
            canShoot = false;
        }
            
    }
} 