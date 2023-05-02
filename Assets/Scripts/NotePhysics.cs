using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotePhysics : MonoBehaviour
{
    public Note note;
    public float beatTempo;

    public bool hasStarted;

    // Start is called before the first frame update
    void Start()
    {
        beatTempo /= 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted)
        {
           /* if(Input.anyKeyDown)
            {
                hasStarted = true;
            }*/
        } else 
        {
            transform.position -= new Vector3(0, 0, beatTempo * Time.deltaTime);
        }
    }
}
