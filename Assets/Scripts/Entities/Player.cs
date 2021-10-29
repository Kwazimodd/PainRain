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
    private Animator _animator;

    public Vector2 Velocity
    {
        get { return rigidbody2D.velocity; }
        private set
        {
            rigidbody2D.velocity = value;
            OnVelocityChange();
        }
    }
    protected override void Awake()
    {
        base.Awake();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        
    }

    private void OnMove(InputValue value)
    {
        Vector2 inputMovement = value.Get<Vector2>();
        Velocity = inputMovement*moveSpeed;
    }

    private void OnVelocityChange()
    {
        if (Velocity == Vector2.zero)
        {
            _animator.SetBool("Idle", true);
        }
        else
        {
            _animator.SetBool("Idle", false);
            
            if (Velocity.x > 0)
            {
                _animator.SetInteger("move", 1);
            }
            else if (Velocity.x < 0)
            {
                _animator.SetInteger("move", 3);
            }
            else if (Velocity.y > 0)
            {
                _animator.SetInteger("move", 2);
            }
            else if (Velocity.y < 0)
            {
                _animator.SetInteger("move", 0);
            }
        }
    }
    
    public void ChangeMoveSpeed(float changer)
    {
        moveSpeed *= changer;
    }
}