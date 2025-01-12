using UnityEngine;

public class SyncStateWithPerson : MonoBehaviour
{
    public GameObject person;

    void Update()
    {
        if (person != null)
        {
            gameObject.SetActive(person.activeSelf);
        }
    }
}