using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialDealer : MonoBehaviour
{
    public GameObject material_to_deal;
    [HideInInspector]
    public bool deal_own = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject getItsMaterial()
    {
        if (deal_own)
            return this.gameObject;
        else
        {
            GameObject obj = Object.Instantiate(material_to_deal, transform.position, material_to_deal.transform.rotation);
            obj.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            Collider rb = obj.GetComponent<Collider>();
            //rb.isTrigger = false;
            return obj;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        StoringItems component = collision.gameObject.GetComponent<StoringItems>();
        if (component != null && component.object_counter < component.max_carryin_items)
        {
            component.carrying_objects[component.object_counter] = getItsMaterial();
            if (component.object_counter != 0)
            {
                component.carrying_objects[component.object_counter].transform.position = component.carrying_objects[component.object_counter - 1].transform.position - component.carrying_objects[component.object_counter - 1].transform.forward;
                //component.carrying_objects[component.object_counter].GetComponent<SpringJoint>().connectedBody = component.carrying_objects[component.object_counter-1].GetComponent<Rigidbody>();
            }
            else
            {
                component.carrying_objects[component.object_counter].transform.position = component.gameObject.transform.position - component.gameObject.transform.forward;
                //component.carrying_objects[component.object_counter].GetComponent<SpringJoint>().connectedBody = component.own_rb;
            }


            component.object_counter++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
