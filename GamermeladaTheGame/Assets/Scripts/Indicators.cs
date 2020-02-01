using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicators : MonoBehaviour
{
    public GameObject[] indicators;
    public GameObject[] to_point;
    public GameObject player;
    Camera maincamera;
    // Start is called before the first frame update
    void Start()
    {
        maincamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        return;
        Vector2 halfScreenSize = new Vector2(Screen.currentResolution.width*0.5f, Screen.currentResolution.height*0.5f);
        Debug.Log(halfScreenSize);
        Vector3 scrtocam = maincamera.WorldToScreenPoint(player.transform.position);
        for (int i = 0; i < to_point.Length; ++i)
        {
            //Vector3 point_des = maincamera.WorldToScreenPoint(to_point[i].transform.position);
            Vector3 point_des = to_point[i].transform.position - player.transform.position;
            Vector3 subs = maincamera.WorldToScreenPoint(point_des);
            Debug.Log(subs);
            RectTransform rectt = indicators[i].GetComponent<RectTransform>();
            if(subs.x >= halfScreenSize.x*2.0f)
            {
                //show indicators at place
                float x = (halfScreenSize.x * subs.y - scrtocam.y * point_des.x) * (-Screen.currentResolution.width) / (( halfScreenSize.x - subs.x)*(-Screen.currentResolution.height) -(halfScreenSize.y - subs.y)*(-Screen.currentResolution.width));
                float y = (halfScreenSize.x * subs.y - scrtocam.y * point_des.x) * (-Screen.currentResolution.height) / ((halfScreenSize.x - subs.x) * (-Screen.currentResolution.height) - (halfScreenSize.y - subs.y) * (-Screen.currentResolution.width));

                x = Mathf.Min(Screen.currentResolution.width*0.5f, Mathf.Max(-Screen.currentResolution.width * 0.5f, x));
                y = Mathf.Min(Screen.currentResolution.height*0.5f, Mathf.Max(-Screen.currentResolution.height * 0.5f, y));
                rectt.position = new Vector3(x, y, 1);
                indicators[i].SetActive(true);
            }
            else if(subs.y >= halfScreenSize.y * 2.0f)
            {
                //show indicators at place
                float x = (halfScreenSize.x * subs.y - scrtocam.y * point_des.x) * (-Screen.currentResolution.width) / ((halfScreenSize.x - subs.x) * (-Screen.currentResolution.height) - (halfScreenSize.y - subs.y) * (-Screen.currentResolution.width));
                float y = (halfScreenSize.x * subs.y - scrtocam.y * point_des.x) * (-Screen.currentResolution.height) / ((halfScreenSize.x - subs.x) * (-Screen.currentResolution.height) - (halfScreenSize.y - subs.y) * (-Screen.currentResolution.width));

                x = Mathf.Min(Screen.currentResolution.width * 0.5f, Mathf.Max(-Screen.currentResolution.width * 0.5f, x));
                y = Mathf.Min(Screen.currentResolution.height * 0.5f, Mathf.Max(-Screen.currentResolution.height * 0.5f, y));
                rectt.position = new Vector3(x, y, 1);
                indicators[i].SetActive(true);

            }
            else if(subs.x < 0.0f)
            {
                //show indicators at place
                float x = (halfScreenSize.x * subs.y - scrtocam.y * point_des.x) * (-Screen.currentResolution.width) / ((halfScreenSize.x - subs.x) * (-Screen.currentResolution.height) - (halfScreenSize.y - subs.y) * (-Screen.currentResolution.width));
                float y = (halfScreenSize.x * subs.y - scrtocam.y * point_des.x) * (-Screen.currentResolution.height) / ((halfScreenSize.x - subs.x) * (-Screen.currentResolution.height) - (halfScreenSize.y - subs.y) * (-Screen.currentResolution.width));

                x = Mathf.Min(Screen.currentResolution.width * 0.5f, Mathf.Max(-Screen.currentResolution.width * 0.5f, x));
                y = Mathf.Min(Screen.currentResolution.height * 0.5f, Mathf.Max(-Screen.currentResolution.height * 0.5f, y));
                rectt.position = new Vector3(x, y, 1);
                indicators[i].SetActive(true);
            }
            else if(subs.y < 0.0f)
            {
                //show indicators at place
                float x = (halfScreenSize.x * subs.y - scrtocam.y * point_des.x) * (-Screen.currentResolution.width) / ((halfScreenSize.x - subs.x) * (-Screen.currentResolution.height) - (halfScreenSize.y - subs.y) * (-Screen.currentResolution.width));
                float y = (halfScreenSize.x * subs.y - scrtocam.y * point_des.x) * (-Screen.currentResolution.height) / ((halfScreenSize.x - subs.x) * (-Screen.currentResolution.height) - (halfScreenSize.y - subs.y) * (-Screen.currentResolution.width));

                x = Mathf.Min(Screen.currentResolution.width * 0.5f, Mathf.Max(-Screen.currentResolution.width * 0.5f, x));
                y = Mathf.Min(Screen.currentResolution.height * 0.5f, Mathf.Max(-Screen.currentResolution.height * 0.5f, y));
                rectt.position = new Vector3(x, y, 1);
                indicators[i].SetActive(true);
            }
            else
            {
                indicators[i].SetActive(false);
            }
        }
    }
}
