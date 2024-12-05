using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraScript : MonoBehaviour
{
    public GameObject CameraMain;
    public GameObject CameraPC;
    public GameObject CameraPaper;

    private Camera playerCamera;

    void Start()
    {
        // Initialize cameras
        CameraMain.SetActive(true);
        CameraPC.SetActive(false);
        CameraPaper.SetActive(false);

        // Initialize the playerCamera to the main camera
        playerCamera = CameraMain.GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            // Check if the pointer is over a UI element
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                DetectObject();
            }
        }
    }

    void DetectObject()
    {
        // Raycast from the center of the screen
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.collider.gameObject;

            // Check the tag of the hit object
            if (hitObject.CompareTag("PC"))
            {
                Camera2();
            }
            else if (hitObject.CompareTag("Paper"))
            {
                Camera3();
            }
            else
            {
                Camera1();
            }
        }
    }

    void Camera1()
    {
        CameraMain.SetActive(true);
        CameraPC.SetActive(false);
        CameraPaper.SetActive(false);

        // Update playerCamera reference
        playerCamera = CameraMain.GetComponent<Camera>();
    }

    void Camera2()
    {
        CameraMain.SetActive(false);
        CameraPC.SetActive(true);
        CameraPaper.SetActive(false);

        // Update playerCamera reference
        playerCamera = CameraPC.GetComponent<Camera>();
    }

    void Camera3()
    {
        CameraMain.SetActive(false);
        CameraPC.SetActive(false);
        CameraPaper.SetActive(true);

        // Update playerCamera reference
        playerCamera = CameraPaper.GetComponent<Camera>();
    }
}