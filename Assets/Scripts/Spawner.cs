using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float queueTime = 2;
    private float time = 0;
    public GameObject obstacle;
    public float height;

    // Reference to GameManager to check if the game is paused.
    public GameManager gameManager;

    // Update is called once per frame
    void Update()
    {
        // Check if the game is paused
        if (gameManager.isPaused)
            return;

        if (time > queueTime)
        {
            GameObject go = Instantiate(obstacle);
            go.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);

            time = 0;

            Destroy(go, 50);
        }

        time += Time.deltaTime;
    }
}
