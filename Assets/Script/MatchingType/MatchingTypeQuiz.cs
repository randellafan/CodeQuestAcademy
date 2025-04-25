using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(LineRenderer))]

public class MatchingTypeQuiz : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] private int matchId;
    private bool isDragging;
    private Vector3 endPoint;
    private MatchingType matchingType;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                isDragging = true;
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z= 0f;
                lineRenderer.SetPosition(0,mousePosition);
            }
        }
        if (isDragging)
        {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z= 0f;
                lineRenderer.SetPosition(1,mousePosition); 
                endPoint = mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            RaycastHit2D hit = Physics2D.Raycast(endPoint,Vector2.zero);
            if (hit.collider != null && hit.collider.TryGetComponent(out matchingType) && matchId == matchingType.Get_ID())
            {
                Debug.Log("Correct form!");
                this.enabled = false;
            }
            else
            {
                lineRenderer.positionCount = 0;
            }

            lineRenderer.positionCount = 2;
        }
    }
}
