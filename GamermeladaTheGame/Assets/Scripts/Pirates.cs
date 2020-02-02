using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirates : MonoBehaviour
{
    [HideInInspector]
    public enum MATERIALS { PADEL = 0, SHOVEL = 1, SWORD = 2, CHEST = 3, CANNON = 4, RUM =5};

    MATERIALS[] asked;
    int objects_left = 0;

    public MeshFilter boat_correct;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEvent(Collider collider)
    {
        StoringItems storboat = collider.gameObject.GetComponent<StoringItems>();
        if(storboat != null)
        {
            storboat.object_counter = 0;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(objects_left == 0)
        {
            MeshFilter render = gameObject.GetComponent<MeshFilter>();
            render = boat_correct;
            return;
        }
    }
}
