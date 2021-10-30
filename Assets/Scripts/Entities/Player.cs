using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Player: BaseEntity
{
    private void OnMove(InputValue value)
    {
        Vector2 inputMovement = value.Get<Vector2>();
        Velocity = inputMovement*moveSpeed;
    }

    public void ChangeMoveSpeed(float changer)
    {
        moveSpeed *= changer;
    }
}