using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Vector3 playerStartPosition = new Vector3(0, 0, 0); // Desired reset position for the player.
    public bool isPaused = true; // Game starts paused.
    private AudioSource WingFlap;
    private AudioSource GameLoss;
    public NPCConversation ConversationPerson1;
    public GameObject Person1;
    public NPCConversation ConversationPerson2;
    public GameObject Person2;
    public NPCConversation ConversationPerson3;
    public GameObject Person3;
    public NPCConversation ConversationPerson4;
    public GameObject Person4;
    public NPCConversation ConversationPerson5;
    public GameObject Person5;
    public NPCConversation ConversationPerson6;
    public GameObject Person6;
    public NPCConversation ConversationPerson7;
    public GameObject Person7;
    public NPCConversation ConversationPerson8;
    public GameObject Person8;
    public NPCConversation ConversationPerson9;
    public GameObject Person9;
    private HashSet<GameObject> completedDialogues = new HashSet<GameObject>();


    void Start()
    {
        PauseGame(); // Start with the game paused.
        AudioSource[] audioSources = GetComponents<AudioSource>();
        WingFlap = audioSources[0];
        GameLoss = audioSources[1]; 
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
            WingFlap.Play();
            StartCoroutine(TriggerDialogueAfterDelay(5f));
        }
    }

    public void StartGame()
    {
        isPaused = false; // Resume game.
        player.EnablePlayer(); // Enable player controls and physics.
    }

    public void GameOver()
    {
        GameLoss.Play();
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

    private IEnumerator TriggerDialogueAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        
        TriggerDialogueForPerson(Person1, ConversationPerson1);
        TriggerDialogueForPerson(Person2, ConversationPerson2);
        TriggerDialogueForPerson(Person3, ConversationPerson3);
        TriggerDialogueForPerson(Person4, ConversationPerson4);
        TriggerDialogueForPerson(Person5, ConversationPerson5);
        TriggerDialogueForPerson(Person6, ConversationPerson6);
        TriggerDialogueForPerson(Person7, ConversationPerson7);
        TriggerDialogueForPerson(Person8, ConversationPerson8);
        TriggerDialogueForPerson(Person9, ConversationPerson9);
    }

    private void TriggerDialogueForPerson(GameObject person, NPCConversation conversation)
    {
        if (person.activeSelf && !completedDialogues.Contains(person))
        {
            ConversationManager.Instance.StartConversation(conversation);
            completedDialogues.Add(person);

        }
    }
}
