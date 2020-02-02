using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Honk : MonoBehaviour
{
    public AudioSource audio_player;
    public AudioClip sound;
    // Start is called before the first frame update
    void Start()
    {
        audio_player.PlayOneShot(sound);
        audio_player.PlayDelayed(2);

    }

    // Update is called once per frame
    void Update()
    {
    }
}
