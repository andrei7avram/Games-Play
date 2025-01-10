using UnityEngine;

public class StickyNoteController : MonoBehaviour
{
    public Camera pcCamera;
    public GameObject stickyNote1;
    public GameObject stickyNote2;
    public GameObject stickyNote3;
    public GameObject stickyNote4;

    private void Update()
    {
        if (pcCamera.gameObject.activeSelf)
        {
            stickyNote1.SetActive(false);
            stickyNote2.SetActive(false);
            stickyNote3.SetActive(false);
            stickyNote4.SetActive(false);
        }
        else
        {
            stickyNote1.SetActive(true);
            stickyNote2.SetActive(true);
            stickyNote3.SetActive(true);
            stickyNote4.SetActive(true);
        }
    }
}