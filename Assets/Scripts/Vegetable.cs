using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetable : Food
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        keyToPress = KeyCode.X;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.veggies.hasStarted)
        {
            animator.SetBool("gameStart", true);
        }

        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);

                GameManager.instance.NoteHit();
            }
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Press")
        {
            canBePressed = true;
        }
    }
    public override void OnTriggerExit(Collider other)
    {
        if (gameObject.activeInHierarchy)
        {
            if (other.tag == "Press")
            {
                canBePressed = false;

                GameManager.instance.NoteMissed();
            }
        }
    }
}
