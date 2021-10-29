using System;
using System.Collections;
using UnityEngine;

public class Spawner: MonoBehaviour
{
    [SerializeField] private Transform _spawnCenter;
    [SerializeField] private GameObject[] _spawnObjects;

    [SerializeField] private float _spawnCooldown;

    [SerializeField] private float _spawnRadiusStart;
    [SerializeField] private float _spawnRadiusEnd;

    [SerializeField] private int _spawnEntitiesCount;


    private void Awake()
    {
    }

    private void Start()
    {
        
    }

    private void Spawn(Vector2 spawnPoint, int indexOfObject)
    {
        Instantiate(_spawnObjects[indexOfObject], spawnPoint, Quaternion.identity);
    }

    private void Spawn() 
    {

    }
}