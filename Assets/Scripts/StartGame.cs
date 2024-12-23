using UnityEngine;

public class SpacePressAction : MonoBehaviour
{
    // This function is called once per frame
    void Update()
    {
        // Check if the space bar was pressed this frame
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Call a method or execute an action
            ExecuteAction();
        }
    }

    // Method to execute when the space bar is pressed
    void ExecuteAction()
    {
        Debug.Log("Space bar pressed!");
        // Add your custom logic here
    }
}