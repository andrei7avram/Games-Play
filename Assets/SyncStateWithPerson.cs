using UnityEngine;

public class SyncStateWithPerson : MonoBehaviour
{
    public GameObject person2; // Reference to the Person 2 GameObject

    void Update()
    {
        if (person2 != null)
        {
            gameObject.SetActive(person2.activeSelf);
        }
    }
}