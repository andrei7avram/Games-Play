using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class Conversation : MonoBehaviour
{
    [SerializeField] private NPCConversation myConversation;
    [SerializeField] private GameObject hoverText;
    private bool isHovering = false;

    private void OnMouseEnter()
    {
        isHovering = true;
        hoverText.SetActive(true);
    }

    private void OnMouseExit()
    {
        isHovering = false;
        hoverText.SetActive(false);
    }

    private void Update()
    {
        if (isHovering && Input.GetKeyDown(KeyCode.F))
        {
             ConversationManager.Instance.StartConversation(myConversation);
        }
    }
}
