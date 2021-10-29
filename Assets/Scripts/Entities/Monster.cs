using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Monster: BaseEntity
{
    [SerializeField] private uint _damage;
    
    private void MoveTo(Vector2 point)
    {
        Vector3 monsterPosition = rigidbody2D.transform.position;
        rigidbody2D.velocity = new Vector2(point.x - monsterPosition.x, point.y - monsterPosition.y)*moveSpeed;
    }

    private void Update()
    {
        MoveTo(GameObject.FindWithTag("Player").transform.position);
    }

    private void OnColliderEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<BaseEntity>().GetDamage(_damage);
            other.rigidbody.AddForce(-rigidbody2D.velocity.normalized, ForceMode2D.Impulse);
        }
    }
}