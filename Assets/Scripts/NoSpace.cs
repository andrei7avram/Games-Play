using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NoSpace : Button
{
    public override void OnSubmit(BaseEventData eventData)
    {
        if (eventData is PointerEventData pointerEventData && pointerEventData.button == PointerEventData.InputButton.Left)
        {
            base.OnSubmit(eventData);
        }

    }
}
