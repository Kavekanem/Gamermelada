using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoringItems : MonoBehaviour
{
    public GameObject deliveringpoint;
    [HideInInspector]
    public GameObject[] carrying_objects;
    [HideInInspector]
    public Vector3[] prev_pos;

    [HideInInspector]
    public int max_carryin_items = 8;
    [HideInInspector]
    public int object_counter = 0;
    public float extra_distance = 1.0f;

    Rigidbody own_rb;
    // Start is called before the first frame update
    void Start()
    {
        carrying_objects = new GameObject[max_carryin_items];
        own_rb = gameObject.GetComponent<Rigidbody>();

    }


    public void OnCollisionEnter(Collision collision)
    {
       object_counter = 0;
    }

    public void leaveitem(GameObject obj)
    {
        for(int i = 0; i < object_counter; ++i)
        {
            if(obj.GetInstanceID() == carrying_objects[i].GetInstanceID())
            {
                object_counter = i;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if(own_rb.velocity.magnitude < 150.0f)
        //{
        //
        //    if(Input.GetKeyDown("w"))
        //    {
        //        own_rb.velocity += new Vector3(0f, 0f, -180.0f);
        //    }
        //    if (Input.GetKeyDown("a"))
        //    {
        //        own_rb.velocity += new Vector3(180.0f, 0f, 0f);
        //    }
        //    else if(Input.GetKeyDown("d"))
        //    {
        //        own_rb.velocity += new Vector3(-180.0f, 0f, 0f);
        //
        //    }
        //}
        //transform.position -= Vector3.Scale(transform.forward, new Vector3(1.0f, 1.0f, 1.0f));
        if (object_counter == 0)
            return;
        Vector3 vec1 = transform.position - carrying_objects[0].transform.position;
        vec1.Normalize();
        carrying_objects[0].transform.position = transform.position - Vector3.Scale(vec1, (transform.lossyScale + carrying_objects[0].transform.lossyScale) * 0.5f* extra_distance);
        //for(int i = 1; i < object_counter; ++i)
        //{
        //    Vector3 vec = carrying_objects[i - 1].transform.position - carrying_objects[i].transform.position;
        //    vec.Normalize();
        //    carrying_objects[i].transform.position = carrying_objects[i-1].transform.position - Vector3.Scale(vec, (transform.lossyScale + carrying_objects[0].transform.lossyScale) * 0.5f*extra_distance);
        //    Rigidbody r = carrying_objects[i].GetComponent<Rigidbody>();
        //    
        //    //if(r.velocity.magnitude < own_rb.velocity.magnitude)
        //    //    r.velocity = r.velocity + Vector3.Scale(vec,own_rb.velocity);
        //}

        Vector3 acceleration = new Vector3(0f,0f,0f);

        for (int i = 0; i < object_counter; ++i)
        {
           Vector3 newpos = 2.0f * (carrying_objects[i].transform.position) - prev_pos[i] + acceleration * Time.deltaTime * Time.deltaTime;
           prev_pos[i] = carrying_objects[i].transform.position;
           carrying_objects[i].transform.position = newpos;
        }


        for (int i = 1; i < object_counter; ++i)
            carrying_objects[i].transform.position = Vector3.Min(Vector3.Max(carrying_objects[i].transform.position, new Vector3(15.0f, 15.0f, 15.0f)), new Vector3(extra_distance, extra_distance, extra_distance));


        float imA1 = 1.0f / own_rb.mass;
        float imB1 = 1.0f / carrying_objects[0].GetComponent<Rigidbody>().mass;

        Vector3 posA1 = gameObject.transform.position;
        Vector3 posB1 = carrying_objects[0].transform.position;
        Vector3 deltapos1 = posB1 - posA1;
        float deltalength1 = deltapos1.magnitude;
        //check for whenever both particles are static, and avoid going to hell.
        float difference1 = (deltalength1 - 1.0f) / (deltalength1 * ((imA1 + imB1) == 0 ? 0.0000001f : (imA1 + imB1)));
        carrying_objects[0].transform.position -= deltapos1 * imB1 * difference1;

        for (int i = 1; i < object_counter; ++i)
        {
            float imA = 1.0f / carrying_objects[i - 1].GetComponent<Rigidbody>().mass;
            float imB = 1.0f / carrying_objects[i].GetComponent<Rigidbody>().mass;

            Vector3 posA = carrying_objects[i - 1].transform.position;
            Vector3 posB = carrying_objects[i].transform.position;
            Vector3 deltapos = posB - posA;
            float deltalength = deltapos.magnitude;
            //check for whenever both particles are static, and avoid going to hell.
            float difference = (deltalength - 1.0f) / (deltalength * ((imA + imB) == 0 ? 0.0000001f : (imA + imB)));
            carrying_objects[i - 1].transform.position += deltapos * imA * difference;
            carrying_objects[i].transform.position -= deltapos * imB * difference;

        }
    }


}
