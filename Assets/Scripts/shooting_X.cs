using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_X : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float bulletspeed = 10f;
    private Vector2 direction;
    private bool canShoot = false;

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
            canShoot=true;
        }
        if (direction != Vector2.zero && canShoot) { 
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position,Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;
            canShoot = false;
            }
    }
}