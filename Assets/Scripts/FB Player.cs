using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocity = 2.4f;
    private Rigidbody2D playerRigidbody;

    // Reference to GameManager
    public GameManager gameManager;

    //Player state.
    public bool isDead = false;
    private bool isPlayerEnabled = false;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        DisablePlayer(); // Disable player physics and controls at the start.
    }

    void Update()
    {
        // Skip movement logic if the game is paused, the player is dead, or the player is disabled.
        if (gameManager.isPaused || isDead || !isPlayerEnabled)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidbody.velocity = Vector2.up * velocity;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Set death state and call GameOver.
        if (!isDead)
        {
            isDead = true;
            playerRigidbody.velocity = Vector2.zero; // Stop movement on death.
            gameManager.GameOver();
        }
    }

    // Enable player physics and controls.
    public void EnablePlayer()
    {
        isPlayerEnabled = true;
        playerRigidbody.bodyType = RigidbodyType2D.Dynamic;
    }

    // Disable player physics and controls.
    public void DisablePlayer()
    {
        isPlayerEnabled = false;
        playerRigidbody.velocity = Vector2.zero; // Stop movement.
        playerRigidbody.bodyType = RigidbodyType2D.Kinematic;
    }

    // Add a reset method for cleaner restart handling.
    public void ResetPlayer()
    {
        isDead = false;
        playerRigidbody.velocity = Vector2.zero; // Reset velocity.
        transform.localPosition = Vector3.zero; // Reset position relative to the canvas.
    }
}
