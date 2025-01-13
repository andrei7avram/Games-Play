using UnityEngine;

public class SyncStateWithPerson : MonoBehaviour
{
    public GameObject person;

    public GameObject Backpack;

    void Update()
    {
        if (person != null)
        {
            Backpack.SetActive(person.activeSelf);
        }
    }
}