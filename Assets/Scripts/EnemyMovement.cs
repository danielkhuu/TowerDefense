using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {


	// Use this for initialization
	void Start () {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath(); //get the path list from pathfinder cs
        StartCoroutine(FollowPath(path)); //look up what this does again
	}

    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
   //         print("Visiting: " + waypoint); 
            yield return new WaitForSeconds(.8f);
        }
    }
}
