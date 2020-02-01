using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialDealer : MonoBehaviour
{
    public GameObject material_to_deal;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject getItsMaterial()
    {
        return Object.Instantiate(material_to_deal, transform.position, material_to_deal.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
