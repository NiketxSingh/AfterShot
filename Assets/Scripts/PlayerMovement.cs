using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {

    public float speed = 5f;
    private Rigidbody2D rb;

    private bool isGrounded;
    private float previous_input_x;
    [SerializeField] private float jumpSpeed = 5f;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {

        Move();
        Jump();
    }


    private void Move() {
        float input_x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(previous_input_x * speed, rb.velocity.y);
        if (input_x != 0) {
            transform.localScale = new Vector3(Mathf.Sign(input_x) * 0.6f, transform.localScale.y, transform.localScale.z);
            previous_input_x = input_x;
        }
    }

    private void Jump() {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Ground")){
            isGrounded = true;
        }
    } 
    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.collider.CompareTag("Ground")){
            isGrounded = false;
        }
    } 
}
