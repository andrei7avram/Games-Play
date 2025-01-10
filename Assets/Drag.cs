using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Canvas canvas;
    private UnityEngine.Vector3 originalScale;
    private UnityEngine.Vector3 originalPosition;
    public RectTransform dropArea;

    public bool isAssigned = false;

    public void Start()
    {
        originalScale = transform.localScale;
    }

    public void DragHandler()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        UnityEngine.Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out pos);
        transform.position = canvas.transform.TransformPoint(pos);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Scale down the image when dragging starts
        transform.localScale = originalScale * 0.6f;
        originalPosition = transform.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Reset the image scale when dragging ends
        transform.localScale = originalScale;

        // Check if the drop area contains the pointer position
        if (IsPointerOverDropArea(eventData.position))
        {
            Debug.Log("Dropped in the correct area!");
            isAssigned = true;
            // Optionally, snap to the drop area position
            transform.position = originalPosition;
        }
        else
        {
            // Reset the image's position to the original position
            transform.position = originalPosition;
            isAssigned = false;
            Debug.Log("Dropped in the wrong area!");
        }
    }

    public void OnDrag(PointerEventData eventData)
    {   
        transform.position = Input.mousePosition;
    }

    private bool IsPointerOverDropArea(UnityEngine.Vector2 pointerPosition)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(dropArea, pointerPosition, canvas.worldCamera, out UnityEngine.Vector2 localPoint);
        return dropArea.rect.Contains(localPoint);
    }
}
