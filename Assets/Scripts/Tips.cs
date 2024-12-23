using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tips : MonoBehaviour
{
    public string message;
    private void OnMouseEnter()
    {
        TipsManager._instance.SetAndShowTooltip(message);
    }

    private void OnMouseExit()
    {
        TipsManager._instance.HideToolTip();
    }
}
