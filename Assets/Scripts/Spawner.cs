using System;
using System.Collections;
using UnityEngine;

public class Spawner: MonoBehaviour
{
    [SerializeField] private Transform _spawnCenter;
    [SerializeField] private GameObject[] _spawnObjects;

    [SerializeField] private float _spawnRadiusStart;
    [SerializeField] private float _spawnRadiusEnd;

    [SerializeField] private int _maxEntitiesCount = 3;
    [SerializeField] private int _currentEntitiesCount;

    [SerializeField] private float _spawnCooldown = 1f;

    private void Awake()
    {

    }

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), 0, _spawnCooldown);
    }

    private void SpawnAtThePoint(Vector2 spawnPoint, int indexOfObject)
    {
        Instantiate(_spawnObjects[indexOfObject], spawnPoint, Quaternion.identity);
    }

    private void Spawn() 
    {
        if (_currentEntitiesCount >= _maxEntitiesCount) return;

        float x = UnityEngine.Random.Range(_spawnRadiusStart, _spawnRadiusEnd);
        float y = UnityEngine.Random.Range(_spawnRadiusStart, _spawnRadiusEnd);

        Vector3 point = new Vector3(x, y);
        Vector3 direction = point - _spawnCenter.position;

        point = Quaternion.Euler(0, 0, UnityEngine.Random.Range(0, 360)) * direction;

        SpawnAtThePoint(point, 0);
        _currentEntitiesCount++;
    }

    void OnDrawGizmosSelected()
    {
        // Drawing start radius
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(_spawnCenter.position, _spawnRadiusStart);

        // Drawing start radius
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_spawnCenter.position, _spawnRadiusEnd);
    }
}