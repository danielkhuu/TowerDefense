using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{

    Vector2Int gridPos;
    const int gridSize = 10;

    public int GetGridSize()
    {
        return gridSize;
    }
    public Vector2Int GetGridPos()
    {                          
        return new Vector2Int(    
            Mathf.RoundToInt(transform.position.x / gridSize) * gridSize,
            Mathf.RoundToInt(transform.position.z / gridSize) * gridSize
        );
    }
    //the prev two lines were once in CubeEditor, but we moved it here so 
    //waypoint is independant from CubeEditor. If we delete CubeEditor, the blue pill will still move

    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>(); //get Cube's top's mesh renderer
        topMeshRenderer.material.color = color;
    }
}

