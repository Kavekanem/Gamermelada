using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var allChestComp = GameObject.FindObjectsOfType<MaterialDealer>();

        //float mindistChest = 99999.0f;
        //GameObject closestChest = null;

        float mindistChest = Vector3.Distance(transform.position, allChestComp[0].gameObject.transform.position);
        GameObject closestChest = allChestComp[0].gameObject;

        for (int i = 1; i < allChestComp.Length; i++)
        {
            float newDist = Vector3.Distance(transform.position, allChestComp[i].gameObject.transform.position);

            if(newDist < mindistChest)
            {
                mindistChest = newDist;
                closestChest = allChestComp[i].gameObject;
            }
        }

        transform.LookAt(closestChest.transform.position, new Vector3(0.0f, 1.0f, 0.0f));
    }
}
