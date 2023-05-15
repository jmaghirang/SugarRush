using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoyWaypoint : Waypoint
{
    private Vector3 targetPosition;
    private Transform targetWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        targetWaypoint = waypoint;
        movementSpeed = 7.0f;
        targetPosition = new Vector3(transform.position.x, targetWaypoint.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        float movementStep = movementSpeed * Time.deltaTime;
        if (GameManager.instance.veggies.hasStarted)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementStep);
            if (transform.position == targetPosition)
            {
                wayPointReached = true;
            }
        }
    }
}
