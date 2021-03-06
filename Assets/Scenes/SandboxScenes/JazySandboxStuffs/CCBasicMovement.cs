﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCBasicMovement : MonoBehaviour
{
    public float speed;
    public bool detectCollisions;
    private CharacterController playerCC;
    void Start()
    {
        playerCC = GetComponent<CharacterController>();
        playerCC.detectCollisions = detectCollisions;
    }

    void Update()
    {
        float hori = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        //float inSprint = Input.GetAxis("Sprint");
        float inSprint = Input.GetKey(KeyCode.LeftShift) ? 1 : 0;

        Vector3 move = (transform.forward * vert) + (transform.right * hori);
        move *= speed;

        if (inSprint > 0)
        {
            // ?
        }
        else
        {
            playerCC.SimpleMove(move);
        }
    }
}
