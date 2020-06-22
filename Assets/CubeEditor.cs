using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode] //moving cube in editor mode will show console responses
[SelectionBase] //the first click will select the parent object

public class CubeEditor : MonoBehaviour
{

    [SerializeField] [Range(1f,20f)] float gridSize = 10f;

    TextMesh textMesh;

    void Update()
    {
        Vector3 snapPos;

        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) *gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);

        textMesh = GetComponentInChildren<TextMesh>(); //grabs textmesh from cube top
        string labelText = snapPos.x / gridSize + "," + snapPos.z / gridSize;
        textMesh.text = labelText;
        gameObject.name = "Cube " + labelText;
    }
}
