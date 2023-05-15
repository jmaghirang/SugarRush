using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Transform waypoint;
    private Transform targetWaypoint;

    public float movementSpeed = 5.0f;

    public bool wayPointReached;

    // Use this for initialization
    void Start()
    {
        targetWaypoint = waypoint; //Set the first target waypoint at the start so the enemy starts moving towards a waypoint
    }

    // Update is called once per frame
    void Update()
    {
        float movementStep = movementSpeed * Time.deltaTime;
        if(GameManager.instance.veggies.hasStarted)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, movementStep);
            if (transform.position == targetWaypoint.position)
            {
                wayPointReached = true;
            }
        }
    }
}