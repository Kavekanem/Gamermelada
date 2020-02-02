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

    public float velocity_offset = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        carrying_objects = new GameObject[max_carryin_items];
        prev_pos = new SpringJoint[max_carryin_items];

        own_rb = gameObject.GetComponent<Rigidbody>();

    }


    public void OnCollisionEnter(Collision collision)
    {
       for(int i = 0; i < object_counter; ++i)
       {
            GameObject.Destroy(carrying_objects[i]);
       }
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
        if (object_counter == 0)
            return;

        Vector3 vec1 = transform.position - carrying_objects[0].transform.position;
        vec1.Normalize();
        carrying_objects[0].transform.position = transform.position - Vector3.Scale(vec1, (transform.lossyScale + carrying_objects[0].transform.lossyScale) * 0.5f* extra_distance);
        for(int i = 1; i < object_counter; ++i)
        {
            Vector3 vec = carrying_objects[i - 1].transform.position - carrying_objects[i].transform.position;
            vec.Normalize();
            carrying_objects[i].transform.position = carrying_objects[i-1].transform.position - Vector3.Scale(vec, (transform.lossyScale + carrying_objects[0].transform.lossyScale) * 0.5f*extra_distance);
        }
    }
}
