using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BioActive : MonoBehaviour
{
    public PC pcRef;
    public BoxCollider colliderBio;
    public void Update () {
        if(pcRef.worldSpaceCanvas.worldCamera == pcRef.targetCamera) {
            colliderBio.enabled = true;
        } else {
            colliderBio.enabled = false;
        }
    }
}
