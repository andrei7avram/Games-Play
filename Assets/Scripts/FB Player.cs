using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocity = 2.4f;
    private Rigidbody2D rigidbody;

    // Reference to GameManager.
    public GameManager gameManager;

    // Player state.
    public bool isDead = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Allow movement only if not dead.
        if (Input.GetKeyDown(KeyCode.Space) && !isDead)
        {
            rigidbody.velocity = Vector2.up * velocity;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Set death state and call GameOver.
        if (!isDead)
        {
            isDead = true;
            rigidbody.velocity = Vector2.zero; // Stop movement on death.
            gameManager.GameOver();
        }
    }

    // Add a reset method for cleaner restart handling.
    public void ResetPlayer()
    {
        isDead = false;
        rigidbody.velocity = Vector2.zero; // Reset velocity.
        transform.localPosition = Vector3.zero; // Reset position relative to the canvas.
    }
}