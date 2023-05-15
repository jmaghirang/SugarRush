using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sweet : Food
{
    // Start is called before the first frame update
    void Start()
    {
        keyToPress = KeyCode.Z;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);

                GameManager.instance.NoteHit();
                if (GameManager.instance.missCounter < 49)
                {
                    GameManager.instance.missCounter += 2;
                    GameManager.instance.missText.text = GameManager.instance.missCounter.ToString();
                }
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
            }
        }
    }
}
