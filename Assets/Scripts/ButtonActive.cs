using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActive : MonoBehaviour
{
    public PC pc;

    public Button button;

    public void Update() {
        if (pc.worldSpaceCanvas.worldCamera == pc.targetCamera) {
            button.enabled = true;
            button.image.enabled = true;
        } else {
            button.enabled = false;
            button.image.enabled = false;
        }
    }
}
