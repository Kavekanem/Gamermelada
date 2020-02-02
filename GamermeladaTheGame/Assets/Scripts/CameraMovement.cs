using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject Player = null;
    public float Speed = 1.0f;

    Vector3 InitialOffset;

    private void Start()
    {
        if (Player)
        {
            Vector3 PlayerXZ = new Vector3(Player.transform.position.x, 0.0f, Player.transform.position.z);
            Vector3 CameraXZ = new Vector3(transform.position.x, 0.0f, transform.position.z);

            InitialOffset = CameraXZ - PlayerXZ;
            print(InitialOffset);
        }
    }

    void FixedUpdate()
    {
        if (Player)
        {
            Vector3 PlayerXZ = new Vector3(Player.transform.position.x, 0.0f, Player.transform.position.z);
            Vector3 CameraXZ = new Vector3(transform.position.x, 0.0f, transform.position.z);

            Vector3 Direction = ((PlayerXZ + InitialOffset)  - CameraXZ).normalized;

            float Distance = Vector3.Distance((PlayerXZ + InitialOffset), CameraXZ);

            if(Distance > 5.0f)
            {
                transform.position += Direction * Distance * Speed * Time.deltaTime;
            }
        }
    }
}
