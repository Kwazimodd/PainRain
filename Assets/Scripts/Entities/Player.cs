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
    private bool _isOnPuddle = false;
    
    public int Health
    {
        get 
        {
            return health;
        }
    }

    public void OnMove(InputValue value)
    {
        Vector2 inputMovement = value.Get<Vector2>();
        Move(inputMovement*moveSpeed);
    }

    private void Move(Vector2 velocityVector)
    {
        Velocity = velocityVector;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(typeof(Puddle), out Component component) && !_isOnPuddle)
        {
            moveSpeed /= 2;
            _isOnPuddle = true;
            Move(Velocity.normalized*moveSpeed);
        }
        
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(typeof(Puddle), out Component component) && _isOnPuddle)
        {
            moveSpeed *= 2;
            _isOnPuddle = false;
            Move(Velocity.normalized*moveSpeed);
        }
        
    }
}