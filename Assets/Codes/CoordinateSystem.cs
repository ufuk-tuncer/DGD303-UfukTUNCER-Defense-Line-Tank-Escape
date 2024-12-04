using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using System;

[ExecuteAlways]
public class CoordinateSystem : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color updatedColor = Color.red;


    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Waypoint waypoint;

    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        
        waypoint = GetComponentInParent<Waypoint>();
        DisplayCoordinates();        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }

        ColorUpdates();
        LabelToggling();
    }

    private void LabelToggling()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }

    private void ColorUpdates()
    {
        if (waypoint.IsAvailable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = updatedColor;
        }
    }

    private void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

        label.text = coordinates.x + "," + coordinates.y;
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
