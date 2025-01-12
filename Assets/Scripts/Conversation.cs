using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class Conversation : MonoBehaviour
{
    [SerializeField] private NPCConversation myConversation;
    // [SerializeField] private GameObject hoverText;

    // private void OnMouseEnter()
    // {
    //     hoverText.SetActive(true);
    // }

    // private void OnMouseExit()
    // {
    //     hoverText.SetActive(false);
    // }

    private void OnMouseDown()
    {
        ConversationManager.Instance.StartConversation(myConversation);
    }
}
