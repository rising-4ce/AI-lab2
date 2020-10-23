﻿using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class FlyCamera : MonoBehaviour
{
    [SerializeField]
    private readonly float mainSpeed = 25.0f; //regular speed
    [SerializeField]
    private readonly float shiftAdd = 50.0f; //multiplied by how long shift is held.  Basically running
    [SerializeField]
    private readonly float maxShift = 200.0f; //Maximum speed when holdin gshift
    [SerializeField]
    private readonly float camSens = 0.2f; //How sensitive it with mouse
    [SerializeField]
    private readonly float verticalSpeed = 20.0f;
    private Vector3 lastMouse = new Vector3(0,0,0); //kind of in the middle of the screen, rather than at the top (play)
    private float totalRun = 1.0f;

    private void Start()
    {
        lastMouse = Input.mousePosition;
    }

    void Update()
    {
        // Rotation
        lastMouse = Input.mousePosition - lastMouse;
        lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
        lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
        if (Input.GetMouseButton(0))
        {
            transform.eulerAngles = lastMouse;
        }
        lastMouse = Input.mousePosition;

        // Movement
        Vector3 p = GetBaseInput();
        if (Input.GetKey(KeyCode.LeftShift))
        {
            totalRun += Time.deltaTime;
            p *= totalRun * shiftAdd;
            p.x = Mathf.Clamp(p.x, -maxShift, maxShift);
            p.y = Mathf.Clamp(p.y, -maxShift, maxShift);
            p.z = Mathf.Clamp(p.z, -maxShift, maxShift);
        }
        else
        {
            totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
            p *= mainSpeed;
        }
        p *= Time.deltaTime;
        Vector3 newPosition = transform.position;

        // Position set
        transform.Translate(p);
        newPosition.x = transform.position.x;
        newPosition.z = transform.position.z;
        var verticalDelta = verticalSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
            newPosition.y += verticalDelta;
        if (Input.GetKey(KeyCode.LeftControl))
            newPosition.y -= verticalDelta;
        transform.position = newPosition;
    }

    /*
     * [DllImport("User32.Dll")]
     * public static extern long SetCursorPos(int x, int y);
     * 
     * better camera will be implemented in next version
    */

    private Vector3 GetBaseInput()
    { 
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey(KeyCode.W))
            p_Velocity += new Vector3(0, 0, 1);
        if (Input.GetKey(KeyCode.S))
            p_Velocity += new Vector3(0, 0, -1);
        if (Input.GetKey(KeyCode.A))
            p_Velocity += new Vector3(-1, 0, 0);
        if (Input.GetKey(KeyCode.D))
            p_Velocity += new Vector3(1, 0, 0);
        return p_Velocity;
    }
}