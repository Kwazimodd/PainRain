using System;
using UnityEditor;
using UnityEngine;

public abstract class BaseItem: MonoBehaviour
{
    protected Collider2D collider2D;

    protected virtual void Awake()
    {
        collider2D = new Collider2D();
    }

    public abstract void Interaction();
}