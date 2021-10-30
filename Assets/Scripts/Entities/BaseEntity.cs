using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseEntity : MonoBehaviour
{
    protected Rigidbody2D _rigidbody2D;
    protected Collider2D _collider2D;
    protected Animator _animator;
    [SerializeField] protected int health;
    [SerializeField] protected float moveSpeed;

    public Vector2 Velocity
    {
        get { return _rigidbody2D.velocity; }
        protected set
        {
            _rigidbody2D.velocity = value;
            OnVelocityChange();
        }
    }

    protected virtual void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
        _animator = GetComponent<Animator>();
    }

    public virtual void GetDamage(uint damage)
    {
        health -= (int)damage;
        if (health <= 0) Kill();
    }

    protected virtual void Kill()
    {
        GameObject.Destroy(gameObject);
    }
    
    protected void OnVelocityChange()
    {
        if (Velocity == Vector2.zero)
        {
            _animator.SetBool("Idle", true);
        }
        else
        {
            _animator.SetBool("Idle", false);
            
            if ((int)Velocity.x > 0)
            {
                _animator.SetInteger("move", 1);
            }
            else if ((int)Velocity.x < 0)
            {
                _animator.SetInteger("move", 3);
            }
            else if ((int)Velocity.y > 0)
            {
                
                _animator.SetInteger("move", 2);
            }
            else if ((int)Velocity.y < 0)
            {
                _animator.SetInteger("move", 0);
            }
        }
    }
}
