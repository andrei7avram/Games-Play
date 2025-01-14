using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PC : MonoBehaviour
{
    public GameObject[] panels = new GameObject[6];

    public Camera targetCamera; 
    public Camera currentCamera; 
    public Camera posterCamera; 
    public Canvas worldSpaceCanvas;
    public PersonaManager personaManager;

    public AudioClip bellSound;

    public Canvas FlyerCanvas;

    public GameObject dialogueBox;

    Ray ray;

    public bool isTargetCameraActive = false;
    public bool isPosterCameraActive = false;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && !personaManager.isLevelComplete) 
        {
            if (!isTargetCameraActive && !isPosterCameraActive) {
                ray = currentCamera.ScreenPointToRay(Input.mousePosition);
            }else if (!(isPosterCameraActive)) {
                ray = targetCamera.ScreenPointToRay(Input.mousePosition);
            }
            else {
                ray = posterCamera.ScreenPointToRay(Input.mousePosition);
            }
             
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 1000000, Color.red, 2f);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Hit object: " + hit.collider.gameObject.name);
                if (hit.collider.gameObject.CompareTag("Monitor"))
                {   
                    isTargetCameraActive = true;
                    isPosterCameraActive = false;
                    SwitchToTargetCamera();
                    worldSpaceCanvas.worldCamera = targetCamera;
                    ray = targetCamera.ScreenPointToRay(Input.mousePosition);
                    Debug.Log("Switching to target camera");
                   
                }else if (hit.collider.gameObject.CompareTag("Flyers") && dialogueBox.activeSelf == false) {
                    
                    FlyerCanvas.enabled = true;
                    Debug.Log("FlyerCanvas active");
                    
                }else if (hit.collider.gameObject.CompareTag("Bell")) {
                    personaManager.bellIncrement();
                    GetComponent<AudioSource>().PlayOneShot(bellSound);


                }
                 else if (hit.collider.gameObject.CompareTag("Poster")) {
                    
                    isTargetCameraActive = false;
                    isPosterCameraActive = true;
                    SwitchToPosterCamera();
                    worldSpaceCanvas.worldCamera = posterCamera;
                    ray = posterCamera.ScreenPointToRay(Input.mousePosition);
                    Debug.Log("Switching to poster camera");
                    
                } else {   
                    isTargetCameraActive = false;
                    isPosterCameraActive = false;
                    SwitchToCurrentCamera();
                    Debug.Log("Switching to current camera");
                    worldSpaceCanvas.worldCamera = currentCamera;
                    ray = currentCamera.ScreenPointToRay(Input.mousePosition);
                }
            }
        }
    }

    void SwitchToTargetCamera()
{
    currentCamera.gameObject.SetActive(false); 
    targetCamera.gameObject.SetActive(true); 
    posterCamera.gameObject.SetActive(false);
    worldSpaceCanvas.worldCamera = targetCamera; // Add here
}

void SwitchToCurrentCamera()
{
    targetCamera.gameObject.SetActive(false); 
    currentCamera.gameObject.SetActive(true); 
    posterCamera.gameObject.SetActive(false);
    worldSpaceCanvas.worldCamera = currentCamera; // Add here
}

void SwitchToPosterCamera()
{
    targetCamera.gameObject.SetActive(false); 
    currentCamera.gameObject.SetActive(false); 
    posterCamera.gameObject.SetActive(true);
    worldSpaceCanvas.worldCamera = posterCamera; // Add here
}

    public void Button()
    {
        Debug.Log("Button pressed");
    }

    public void Background()
    {
        ShowPanel(0);
    }

    public void Bio()
    {
        ShowPanel(1);
    }

    public void Email()
    {
        ShowPanel(2);
    }

    public void Game()
    {
        ShowPanel(3);
    }

    public void Help()
    {
        ShowPanel(4);
    }

    public void Studies()
    {
        ShowPanel(5);
    }

    private void ShowPanel(int index)
    {
        for (int i = 0; i < panels.Length; i++)
        {
            if (i == index)
            {
                panels[i].SetActive(true);
            }
            else
            {
                panels[i].SetActive(false);
            }
        }
    }
}
