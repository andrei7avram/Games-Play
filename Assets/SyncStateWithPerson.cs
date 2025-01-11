using UnityEngine;

public class SyncStateWithPerson : MonoBehaviour
{
    public GameObject person2; // Reference to the Person 2 GameObject

    void Update()
    {
        // Check if person2 is assigned
        if (person2 != null)
        {
            // Enable or disable this GameObject based on the active state of person2
            gameObject.SetActive(person2.activeSelf);
        }
    }
}