using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int health;
    private const int maxHealth = 10;
    [SerializeField] private Slider healthSlider;
    private SceneController sceneController;

    private void Start() {
        health = maxHealth;
        sceneController = GameObject.FindGameObjectWithTag("SceneController").GetComponent<SceneController>();

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Spike") || collision.gameObject.CompareTag("Shield")) {
            health--;
        }
    }

    private void Update() {
        if (health <= 0) {
            sceneController.LoadScene("MainMenu");
        }
        healthSlider.value = health;
    }

    
}
