using System;
using System.Collections;
using UnityEngine;

public class Spawner: MonoBehaviour
{
    private CircleCollider2D _collider2D;
    [SerializeField] private GameObject _spawnCenter;
    [SerializeField] private GameObject _spawnObject;
    [SerializeField] private float _spawnCooldown;

    private void Awake()
    {
        _collider2D = GetComponent<CircleCollider2D>();
    }

    private void Spawn(Vector2 spawnPoint)
    {
        Instantiate(_spawnObject, spawnPoint, Quaternion.identity);
    }
}