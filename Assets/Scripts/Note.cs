using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress))
        {
            if(canBePressed)
            {
               gameObject.SetActive(false);

               GameManager.instance.NoteHit();
            }
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Press")
        {
            canBePressed = true;
        }
    }
    private void OnTriggerExit(Collider other)
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
