using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bombPrefab;
    public Transform shootPoint;
    public float bulletspeed = 10f;
    private Vector2 direction;
    private Vector3 rotation;
    private bool canShoot = false;
    public int enemyKilled = 0;
    public int totalKills = 0;
    public bool bombMode = false;

    private SceneController sceneController;
    private void Start() {
        sceneController = GameObject.FindGameObjectWithTag("SceneController").GetComponent<SceneController>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            direction = Vector2.right;
            rotation = Vector3.zero;
            canShoot = true;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            direction = Vector2.left;
            rotation = new Vector3(0,0,180f);
            canShoot = true;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            direction = Vector2.up;
            rotation = new Vector3(0, 0, 90f);
            canShoot = true;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            direction = Vector2.down;
            rotation = new Vector3(0, 0, -90f);
            canShoot = true;
        }
        if (Input.GetKeyDown(KeyCode.E) && enemyKilled >= 5)
        {
            bombMode = !bombMode;
        }
        if (direction != Vector2.zero && canShoot && bombMode == true)
        {
            enemyKilled = 0;
            GameObject bomb = Instantiate(bombPrefab, shootPoint.position, Quaternion.Euler(rotation));
            bomb.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;
            canShoot = false;
        }
        if (direction != Vector2.zero && canShoot && bombMode == false)
        {
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.Euler(rotation));
            bullet.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;
            canShoot = false;
        }
        
        if(sceneController.CurrentScene() == "Level1" && totalKills >= 20) {
            SceneController.Instance.LoadScene("Level2");
            totalKills = 0;
            enemyKilled = 0;
        }
        else if(sceneController.CurrentScene() == "Level2" && totalKills >= 10) {
            SceneController.Instance.LoadScene("Level3");
            totalKills = 0;
            enemyKilled = 0;
        }
        if(sceneController.CurrentScene() == "Level3" && totalKills >= 10) {
            SceneController.Instance.LoadScene("Level4");
            totalKills = 0;
            enemyKilled = 0;
        }
        if(sceneController.CurrentScene() == "Level4" && totalKills >= 20) {
            SceneController.Instance.LoadScene("MainMenu");
            totalKills = 0;
            enemyKilled = 0;
        }
    }
} 