using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShootingVegetable : MonoBehaviour
{
    private Animator animator;
    private ShootingVegetable veg;

    public bool startShooting;

    // Start is called before the first frame update
    void Start()
    {
        veg = GetComponent<ShootingVegetable>();
        animator = GetComponent<Animator>();
        startShooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.veggies.hasStarted)
        {
            animator.SetBool("gameStart", true);
        }

        if (veg.GetComponent<Waypoint>().wayPointReached)
        {
            animator.SetBool("gameStart", false);
            animator.SetBool("startShoot", true);
            startShooting = true;
        }
    }
}