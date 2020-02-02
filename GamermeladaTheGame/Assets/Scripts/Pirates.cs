using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirates : MonoBehaviour
{
    //[HideInInspector]
    //public enum MATERIALS { PADEL = 0, SHOVEL = 1, SWORD = 2, CHEST = 3, CANNON = 4, RUM =5};
    //
    //MATERIALS[] asked;

    public Mesh boat_correct;
    public Mesh boat_destroyed;
    public CapsuleCollider collision;
    public Collider collide;


    public float sink_speed = 1.0f;

    //float rotation = 30.0f;
    public float flying_dutchman_sink_time = 3.0f;
    public float flying_dutchman_float_time = 3.0f;

    float counter_sink = 0f;
    float counter_float = 0f;

    public int item_quantity = 0;

    // Start is called before the first frame update
    void Start()
    {
        item_quantity = Random.Range(1, 6);

    }

    void ReloadMaterials()
    {
        MeshFilter mf = gameObject.GetComponent<MeshFilter>();

        mf.mesh = boat_correct;
        collision.enabled = false;

        if (counter_sink < flying_dutchman_sink_time)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - sink_speed * Time.deltaTime, transform.position.z);
            counter_sink += Time.deltaTime;
            return;
        }

        mf.mesh = boat_destroyed;

        if (counter_float < flying_dutchman_float_time)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + sink_speed * Time.deltaTime, transform.position.z);
            counter_float += Time.deltaTime;
            return;
        }

        item_quantity = Random.Range(1, 6);
        collision.enabled = true;
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider == collide)
        {
            StoringItems storboat = collider.gameObject.GetComponent<StoringItems>();
            item_quantity -= storboat.object_counter;
            for (int i = 0; i < storboat.object_counter; ++i)
            {
                GameObject.Destroy(storboat.carrying_objects[i]);
            }

            storboat.object_counter = 0;
            counter_sink = 0f;
            counter_float = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(item_quantity <= 0)
        {
            ReloadMaterials();
        }
    }
}
