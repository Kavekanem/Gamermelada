using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [HideInInspector]
    public bool Right = false;
    [HideInInspector]
    public bool Left = false;

    public KeyCode RightKey = KeyCode.A;
    public KeyCode LeftKey = KeyCode.D;


    public void RightTurnStart()
    {
        Right = true;
    }

    public void RightTurnEnd()
    {
        Right = false;
    }

    public void LeftTurnStart()
    {
        Left = true;
    }

    public void LeftTurnEnd()
    {
        Left = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(RightKey))
            RightTurnStart();

        if (Input.GetKeyUp(RightKey))
            RightTurnEnd();

        if (Input.GetKeyDown(LeftKey))
            LeftTurnStart();

        if (Input.GetKeyUp(LeftKey))
            LeftTurnEnd();
    }
}
