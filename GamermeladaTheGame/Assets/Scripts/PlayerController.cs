using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CharacterController player = gameObject.GetComponent(typeof(CharacterController)) as CharacterController;


        player.Move(new Vector3);
    }
}
