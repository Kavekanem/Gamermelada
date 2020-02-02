using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialDealer : MonoBehaviour
{
    public GameObject material_to_deal;

    public AudioClip[] collisionSounds;
    public AudioSource audio_player;

    public static int current_audio = 0;
    [HideInInspector]
    public bool deal_own = false;

    public float dissapear_time = 5.0f;
    float counter = 0f;

    CapsuleCollider own_collider;

    float counter_anim = 0f;
    public float dist = 15.0f;
    public float speed = 3.0f;


    // Start is called before the first frame update
    void Start()
    {
        own_collider = gameObject.GetComponent<CapsuleCollider>();
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

            AudioClip sound = collisionSounds[current_audio];

            audio_player.PlayOneShot(sound);

            current_audio++;
            if (current_audio >= collisionSounds.Length)
                current_audio = 0;

          
            component.object_counter++;
            own_collider.enabled = false;
            material_to_deal.SetActive(false);
            counter = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (counter_anim >= 2.0f*Mathf.PI)
            counter_anim = 0f;


        material_to_deal.transform.position += material_to_deal.transform.up * Mathf.Sin(counter_anim)*Time.deltaTime*dist;
        counter_anim += speed*Time.deltaTime;


        if (counter < dissapear_time)
        {
            counter += Time.deltaTime;
            return;
        }
        own_collider.enabled = true;
        material_to_deal.SetActive(true);
    }
}
