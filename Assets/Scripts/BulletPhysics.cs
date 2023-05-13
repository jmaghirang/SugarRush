using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPhysics : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(0, 10, true);
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision other)
    {
      //  if(other.gameObject.tag == "bullet")
      //  {
            GameManager.instance.NoteMissed();
            Destroy(gameObject);
     //   }
    }
}