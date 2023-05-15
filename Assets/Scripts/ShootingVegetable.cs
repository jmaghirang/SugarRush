using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShootingVegetable : MonoBehaviour
{
    private Animator animator;

    //public bool playerInRange;
    //public float sightRange;

    //public LayerMask player;

    public bool startShooting;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        startShooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.veggies.hasStarted)
        {
            animator.SetBool("startShoot", true);
            startShooting = true;
        }

        /*playerInRange = Physics.CheckSphere(transform.position, sightRange, player);
        if (playerInRange)
        {
            animator.SetBool("gameStart", false);
            Shoot();
        }*/
    }
}
