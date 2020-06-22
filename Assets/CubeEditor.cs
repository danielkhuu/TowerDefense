using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode] //basically makes this script a tool for us to make the map 
[SelectionBase] //the first click will select the parent object
[RequireComponent(typeof(Waypoint))] 

public class CubeEditor : MonoBehaviour
{
    Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }
    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        transform.position = new Vector3(
            waypoint.GetGridPos().x,
            0f,
            waypoint.GetGridPos().y   //not z because of the movement
            );
    }
    void UpdateLabel()
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>(); //grabs textmesh from cube top
        int gridSize = waypoint.GetGridSize();
        string labelText = 
            waypoint.GetGridPos().x / gridSize + "," + waypoint.GetGridPos().y / gridSize;
        textMesh.text = labelText;
        gameObject.name = "Cube " + labelText;
    }
}
