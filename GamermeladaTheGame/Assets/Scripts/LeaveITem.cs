using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveITem : MonoBehaviour
{

    public StoringItems belong;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    public void OnCollisionEnter(Collision collision)
    {
       // belong.leaveitem(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
