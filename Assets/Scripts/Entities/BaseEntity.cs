using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseEntity : MonoBehaviour
{
    protected Rigidbody2D rigidbody2D;
    protected Collider2D collider2D;
    [SerializeField] protected int health;
    [SerializeField] protected float moveSpeed;

    protected virtual void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }

    public virtual void GetDamage(uint damage)
    {
        health -= (int)damage;
        if (health <= 0) Kill();
    }

    public virtual void Kill()
    {
        Destroy(gameObject);
    }
}
