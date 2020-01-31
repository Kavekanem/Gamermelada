using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoringItems : MonoBehaviour
{
    public GameObject deliveringpoint;
    [HideInInspector]
    public GameObject[] carrying_objects;

    public int max_carryin_items = 8;
    int object_counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        carrying_objects = new GameObject[max_carryin_items];
    }


    public void OnCollisionEnter(Collision collision)
    {
        MaterialDealer component = collision.gameObject.GetComponent<MaterialDealer>();
        if (object_counter < max_carryin_items && component != null)
        {
            carrying_objects[object_counter++] = component.getItsMaterial();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (object_counter == 0)
            return;

        carrying_objects[0].transform.position = transform.position - Vector3.Scale(transform.forward, (transform.lossyScale + carrying_objects[0].transform.lossyScale) * 0.5f);
        for(int i = 1; i < object_counter; ++i)
        {
            carrying_objects[i].transform.position = carrying_objects[i-1].transform.position - Vector3.Scale(carrying_objects[i-1].transform.forward, (transform.lossyScale + carrying_objects[0].transform.lossyScale) * 0.5f);
        }
    }


}
