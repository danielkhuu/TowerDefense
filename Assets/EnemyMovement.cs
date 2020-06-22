using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] List<Waypoint> path;
    [SerializeField] float dwellTime = 1f;

    void Start()
    {
        StartCoroutine(FollowPath()); //kind of like invokeRepeating but embedded
    }

    IEnumerator FollowPath() //for that to work ^ must use IEnumerator and return something
    {
        print("Starting patrol...");
        foreach (Waypoint waypoint in path) //since path has all the cubes, Block waypoint is a cube
        {
            transform.position = waypoint.transform.position;
            print("visiting block: " + waypoint);
            yield return new WaitForSeconds(dwellTime);
        }
        print("Ending patrol.");
    }
}
