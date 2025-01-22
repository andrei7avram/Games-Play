using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocity = 2.4f;
    private Rigidbody2D playerRigidbody;

    // Reference to GameManager
    public GameManager gameManager;

    //Player state.
    public bool isDead = false;

    public PersonaManager personaManager;
    private bool isPlayerEnabled = false;
    private AudioSource WingFlap;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        DisablePlayer(); // Disable player physics and controls at the start.
        WingFlap = GetComponent<AudioSource>();
    }

    void Update()
    {   
        // Skip movement logic if the game is paused, the player is dead, or the player is disabled.
        if (gameManager.isPaused || isDead || !isPlayerEnabled || personaManager.egbertTab.activeSelf == false)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) && personaManager.egbertTab.activeSelf == true)
        {   
            Debug.Log(personaManager.egbertTab.activeSelf);
            playerRigidbody.velocity = Vector2.up * velocity;
            WingFlap.Play();
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
        playerRigidbody.velocity = Vector2.up * velocity;
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
