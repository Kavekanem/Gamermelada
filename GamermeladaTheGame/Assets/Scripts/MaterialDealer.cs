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
            return Object.Instantiate(material_to_deal, transform.position, material_to_deal.transform.rotation);
    }

    void OnTriggerEnter(Collider collision)
    {
        StoringItems component = collision.gameObject.GetComponent<StoringItems>();
        if (component.object_counter < component.max_carryin_items && component != null)
        {
            component.carrying_objects[component.object_counter] = getItsMaterial();
            if (component.object_counter != 0)
                component.carrying_objects[component.object_counter].transform.position = component.carrying_objects[component.object_counter - 1].transform.position - component.carrying_objects[component.object_counter - 1].transform.forward;
            else
                component.carrying_objects[component.object_counter].transform.position = component.gameObject.transform.position + component.gameObject.transform.forward;

            component.prev_pos[component.object_counter] = component.carrying_objects[component.object_counter].transform.position;
            component.object_counter++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
