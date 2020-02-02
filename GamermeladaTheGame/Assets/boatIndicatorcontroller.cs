using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatIndicatorcontroller : MonoBehaviour
{
    public GameObject IndicatorParent = null;
    public StoringItems it;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(it.object_counter > 0)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }

        transform.LookAt(IndicatorParent.transform.position, new Vector3(0.0f, 1.0f, 0.0f));
    }
}
