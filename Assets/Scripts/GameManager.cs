using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Vector3 playerStartPosition = new Vector3(0, 0, 0); // Desired reset position for the player.

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0; // Start game paused.
    }

    private void Update()
    {
        if (player.isDead)
        {
                RestartGame();
        }

        if (Input.GetKeyDown(KeyCode.Space) && !player.isDead)
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        Time.timeScale = 1; // Resume game time.
    }

    public void GameOver()
    {
        Time.timeScale = 0; // Pause game time when the player dies.
    }

    public void RestartGame()
    {
        // Reset player position relative to the canvas.
        player.transform.localPosition = playerStartPosition;

        // Reset Rigidbody2D velocity.
        Rigidbody2D playerRigidbody = player.GetComponent<Rigidbody2D>();
        playerRigidbody.velocity = Vector2.zero;

        // Reset player state.
        player.isDead = false;

        // Destroy all Pipe objects.
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");
        foreach (GameObject pipe in pipes)
        {
            Destroy(pipe);
        }

       Time.timeScale = 0;
    }
}