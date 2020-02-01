using UnityEngine;

public class StoringItems : MonoBehaviour
{
    public GameObject deliveringpoint;
    [HideInInspector]
    public GameObject[] carrying_objects;
    [HideInInspector]
    public SpringJoint[] prev_pos;

    [HideInInspector]
    public int max_carryin_items = 8;
    [HideInInspector]
    public int object_counter = 0;
    public float extra_distance = 1.0f;

    [HideInInspector]
    public Rigidbody own_rb;
    // Start is called before the first frame update
    void Start()
    {
        carrying_objects = new GameObject[max_carryin_items];
        prev_pos = new SpringJoint[max_carryin_items];

        own_rb = gameObject.GetComponent<Rigidbody>();

    }


    public void OnCollisionEnter(Collision collision)
    {
       //object_counter = 0;
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

    }
}
