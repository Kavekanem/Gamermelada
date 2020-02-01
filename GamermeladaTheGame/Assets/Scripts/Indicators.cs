using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicators : MonoBehaviour
{
    public GameObject[] indicators;
    public GameObject[] to_point;
    GameObject player;
    Camera maincamera;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 halfScreenSize = new Vector2(Screen.currentResolution.width * 0.5f, Screen.currentResolution.height * 0.5f);

        Vector3 scrtocam = maincamera.WorldToScreenPoint(player.transform.position, Camera.MonoOrStereoscopicEye.Mono); 
        for (int i = 0; i < to_point.Length; ++i)
        {
            Vector3 point_des = maincamera.WorldToScreenPoint(to_point[i].transform.position, Camera.MonoOrStereoscopicEye.Mono);
            Vector3 subs = point_des - scrtocam;
            if(subs.x >= halfScreenSize.x && subs.y >= halfScreenSize.y)
            {
                //show indicators at place
            }
            else
            {
                indicators[i].SetActive(false);
            }
        }
    }
}
