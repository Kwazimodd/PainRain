﻿using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public delegate void Action();

public class Player: BaseEntity
{
    private static Player instance;

    public static Player Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Player>();
            }
            return instance;
        }
    }

    public event Action OnPlayerDeath;

    private bool _isOnPuddle = false;
    
    public float Health
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

    public void IncreaseSpeed(float value)
    {
        moveSpeed += value;
    }

    public void GetSlowDowned(float modifier) 
    {
        if (!_isOnPuddle) 
        {
            moveSpeed *= modifier;
            _isOnPuddle = true;
            Move(Velocity.normalized * moveSpeed);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Puddle>(out Puddle puddle) && _isOnPuddle)
        {
            moveSpeed /= puddle.SpeedModifier;
            _isOnPuddle = false;
            Move(Velocity.normalized*moveSpeed);
        }
        
    }

    protected override void Kill()
    {
        base.Kill();
        OnPlayerDeath.Invoke();
    }
}