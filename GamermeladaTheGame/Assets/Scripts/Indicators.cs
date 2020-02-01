using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicators : MonoBehaviour
{
    public GameObject[] indicators;
    public GameObject[] to_point;
    GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 halfScreenSize = new Vector2(Screen.currentResolution.width * 0.5f, Screen.currentResolution.height * 0.5f);

        //for (int i = 0; i < to_point.Length; ++i)
        //{
        //    Vector3 cmp = to_point[0].transform.position - player.transform.position;
        //    
        //    //if()
        //}
    }
}
