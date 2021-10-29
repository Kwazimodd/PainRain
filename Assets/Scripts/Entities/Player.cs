using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Player: BaseEntity
{
    private void Update()
    {
        
    }

    private void OnMove(InputValue value)
    {
        Vector2 inputMovement = value.Get<Vector2>();
        rigidbody2D.velocity = inputMovement*moveSpeed;
    }

}