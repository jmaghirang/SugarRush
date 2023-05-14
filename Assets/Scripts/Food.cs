using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;

    public virtual void OnTriggerEnter(Collider other)
    {

    }
    public virtual void OnTriggerExit(Collider other)
    {

    }
}