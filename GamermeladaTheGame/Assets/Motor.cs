using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour
{
    public PlayerMovement player;
    public AudioSource audio_player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = player.GetComponent<Rigidbody>();
        float velocity = rb.velocity.magnitude;

        float pitch_value = Mathf.Lerp(1, 3, velocity / 200);

        audio_player.pitch = pitch_value;
        
    }
}
