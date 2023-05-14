using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMgr : MonoBehaviour
{
    public static EntityMgr instance;

    private void Awake()
    {
        instance = this;
    }

    public List<Note> vegetables;
    public int numberOfVeggies;

    public Vector3 position;
    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        float[] xPosition = { -7.15f, 0f, 7.4f };
        float zPosition = position.z;

        for(int i = 0; i < numberOfVeggies; i++)
        {
            int randomX = Random.Range(0, 3);
            int randomVeggie = Random.Range(0, vegetables.Count);
            position = new Vector3(xPosition[randomX], 0, zPosition);

            var newVeggie = Instantiate(vegetables[randomVeggie], position, transform.rotation);
            newVeggie.transform.parent = gameObject.transform;

            zPosition += offset;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
