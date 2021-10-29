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

    public void ChangeMoveSpeed(float changer)
    {
        moveSpeed *= changer;
    }
}