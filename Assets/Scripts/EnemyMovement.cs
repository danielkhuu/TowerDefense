using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    [SerializeField] float speed = 10f;
    [SerializeField] ParticleSystem goalParticlePrefab;

    List<Waypoint> path;
    int waypointCounter = 0;

    void Start()
    {
        path = FindObjectOfType<Pathfinder>().GetPath();
    }

    private void Update()
    {
        MoveToWaypoint(path[waypointCounter]);
    }

    private void MoveToWaypoint(Waypoint waypoint)
    {
        Vector3 groundPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector3 direction = (waypoint.transform.position - groundPos).normalized;

        float distanceThisFrame = speed * Time.deltaTime;

        if (distanceThisFrame >= Vector3.Distance(waypoint.transform.position, groundPos))
        {
            waypointCounter++;
            return;
        }

        transform.Translate(direction * distanceThisFrame, Space.World);
        if(waypointCounter == path.Count-1)
        {
            SelfDestruct();
        }

    }
    private void SelfDestruct()
    {
        var vfx = Instantiate(goalParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();

        Destroy(vfx.gameObject, vfx.main.duration);
        Destroy(gameObject); //destroy enemy ship
    }
}
