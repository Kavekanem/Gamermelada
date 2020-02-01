using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject Player = null;
    public float Speed = 1.0f;

    void Update()
    {
        Vector3 Direction = (Player.transform.position - transform.position).normalized;
        Direction = new Vector3(Direction.x, 0.0f, Direction.z);

        transform.position += Direction * Vector3.Distance(transform.position, Player.transform.position) * Speed;
    }
}
