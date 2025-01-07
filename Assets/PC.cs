using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PC : MonoBehaviour
{
    public GameObject[] panels = new GameObject[5];

    public Camera targetCamera; 
    public Camera currentCamera; 
    public Canvas worldSpaceCanvas;
    public PersonaManager personaManager;

    Ray ray;

    public bool isTargetCameraActive = false;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && !personaManager.isLevelComplete) 
        {
            if (!isTargetCameraActive) {
                ray = currentCamera.ScreenPointToRay(Input.mousePosition);
            }else {
                ray = targetCamera.ScreenPointToRay(Input.mousePosition);
            }
             
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 1000000, Color.red, 2f);

            if (Physics.Raycast(ray, out hit))
            {
                
                if (hit.collider.gameObject.CompareTag("Monitor"))
                {   
                    isTargetCameraActive = true;
                    SwitchToTargetCamera();
                    worldSpaceCanvas.worldCamera = targetCamera;
                    ray = targetCamera.ScreenPointToRay(Input.mousePosition);
                    Debug.Log("Switching to target camera");
                   
                }else
                {   
                    isTargetCameraActive = false;
                    SwitchToCurrentCamera();
                    worldSpaceCanvas.worldCamera = currentCamera;
                    ray = currentCamera.ScreenPointToRay(Input.mousePosition);
                    Debug.Log(hit.collider.gameObject.name);
                }
            }
        }
    }

    void SwitchToTargetCamera()
    {
        if (currentCamera != null)
        {
            currentCamera.gameObject.SetActive(false); 
        }

        if (targetCamera != null)
        {
            targetCamera.gameObject.SetActive(true); 
        }
    }

    void SwitchToCurrentCamera()
    {
        if (targetCamera != null)
        {
            targetCamera.gameObject.SetActive(false); 
        }

        if (currentCamera != null)
        {
            currentCamera.gameObject.SetActive(true); 
        }
    }

    public void Button()
    {
        Debug.Log("Button pressed");
    }

    public void Main()
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
