using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ClickableText : MonoBehaviour, IPointerClickHandler
{
    private TextMeshProUGUI textMeshPro;
    private Camera mainCamera;
    private Dictionary<string, Action> clickableWords = new Dictionary<string, Action>();
    
    void Awake()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        mainCamera = Camera.main;
        
        // Make sure the text is set to use rich text
        textMeshPro.richText = true;

        RegisterClickableWord("dragon", () => Debug.Log("Dragon clicked!"));
        RegisterClickableWord("sword", () => Debug.Log("Sword clicked!"));
        RegisterClickableWord("treasure", () => Debug.Log("treasure clicked!"));
    }

    public void RegisterClickableWord(string word, Action onClick)
    {
        // Add the word and its callback to our dictionary
        clickableWords[word] = onClick;
        
        // Update the text to make this word clickable
        string originalText = textMeshPro.text;
        string modifiedText = originalText.Replace(
            word, 
            $"<link=\"{word}\"><color=#0099FF>{word}</color></link>"
        );
        textMeshPro.text = modifiedText;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(eventData.position);
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(textMeshPro, worldPosition, mainCamera);
        
        if (linkIndex != -1)
        {
            TMP_LinkInfo linkInfo = textMeshPro.textInfo.linkInfo[linkIndex];
            string word = linkInfo.GetLinkID();
            
            if (clickableWords.ContainsKey(word))
            {
                clickableWords[word].Invoke();
                 Debug.Log($"Clicked on word: {word}");
            }
        }
    }
}

