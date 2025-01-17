using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Person7 : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{
    public Button linkedButton; 
    private Button thisButton; 
    
    private Color invis;

    private void Awake()
    {
        thisButton = GetComponent<Button>();
        invis = thisButton.colors.normalColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        HighlightButton(thisButton, true);
        Debug.Log("Highlighting button");
        HighlightButton(linkedButton, true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HighlightButton(thisButton, false);
        HighlightButton(linkedButton, false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
        DeselectButton();
    }

    private void DeselectButton()
    {
        
        if (EventSystem.current.currentSelectedGameObject == gameObject)
        {
            EventSystem.current.SetSelectedGameObject(null);
        }
    }

    private void HighlightButton(Button button, bool highlight)
    {
        if (button != null)
        {
            ColorBlock colors = button.colors;
            if (highlight)
            {
                colors.normalColor = colors.highlightedColor;
                 Debug.Log("Highlighting button");
            }
            else
            {
                colors.normalColor = invis; 
            }
            button.colors = colors;
        }
    }

    private void SetAlpha(Image image, float alpha)
    {
        if (image != null)
        {
            Color color = image.color;
            color.a = alpha; 
            image.color = color; 
        }
    }
}

