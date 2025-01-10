using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Vector3 playerStartPosition = new Vector3(0, 0, 0); // Desired reset position for the player.
    public bool isPaused = true; // Game starts paused.

    void Start()
    {
        PauseGame(); // Start with the game paused.
    }

    private void Update()
    {
        if (player.isDead)
        {
            RestartGame();
        }

        if (Input.GetKeyDown(KeyCode.Space) && isPaused)
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        isPaused = false; // Resume game.
        player.EnablePlayer(); // Enable player controls and physics.
    }

    public void GameOver()
    {
        PauseGame(); // Pause the game when the player dies.
    }

    public void PauseGame()
    {
        isPaused = true; // Pause the game.
        player.DisablePlayer(); // Disable player controls and physics.
    }

    public void RestartGame()
    {
        // Reset player position relative to the canvas.
        player.transform.localPosition = playerStartPosition;

        // Reset player state.
        player.isDead = false;

        // Destroy all Pipe objects.
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");
        foreach (GameObject pipe in pipes)
        {
            Destroy(pipe);
        }

        PauseGame(); // Pause the game after restarting.
    }
}
