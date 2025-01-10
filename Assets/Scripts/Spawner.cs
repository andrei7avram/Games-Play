using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float queueTime = 2f;
    private float time = 0f;
    public GameObject obstacle;
    public float height;

    // Reference to GameManager to check if the game is paused.
    public GameManager gameManager;

    // Update is called once per frame
    void Update()
    {
        // Check if the game is paused
        if (gameManager.isPaused)
            return; // Stop spawning if the game is paused.

        // Spawn obstacles at regular intervals.
        if (time > queueTime)
        {
            GameObject go = Instantiate(obstacle);
            go.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);

            time = 0f;

            // Destroy the obstacle after 50 seconds
            Destroy(go, 50f);
        }

        // Increment time by deltaTime to keep track of the spawn timing
        time += Time.deltaTime;
    }
}
