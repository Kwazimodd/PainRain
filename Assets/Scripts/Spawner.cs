using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Monster Spawn Properties")]
    [SerializeField] private Transform _spawnCenter;
    [SerializeField] private GameObject[] _spawnMonsters;

    [SerializeField] private float _spawnRadiusStart;
    [SerializeField] private float _spawnRadiusEnd;

    [SerializeField] private int _maxEntitiesCount = 3;
    [SerializeField] private int _currentEntitiesCount;

    [SerializeField] private float _spawnCooldown = 1f;

    [Header("Paper Spawn Properties")]
    [SerializeField] private int _countOfAdditionalPapers;
    [SerializeField] private Transform _paperSpawnPointsHolder;
    [SerializeField] private Transform _papersHolder;

    [SerializeField] private GameObject[] _papers;
    [SerializeField] private List<Transform> _remainedSpawnPoints;

    private void Awake()
    {
        _remainedSpawnPoints = new List<Transform>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(SpawnMonsters), 0, _spawnCooldown);

        foreach (var spawnPoint in _paperSpawnPointsHolder) 
        {
            _remainedSpawnPoints.Add((Transform)spawnPoint);
        }

        SpawnPapers();
    }

    private void SpawnMonsters() 
    {
        if (_currentEntitiesCount >= _maxEntitiesCount) return;

        float x = UnityEngine.Random.Range(_spawnRadiusStart, _spawnRadiusEnd);
        float y = UnityEngine.Random.Range(_spawnRadiusStart, _spawnRadiusEnd);

        Vector3 point = new Vector3(x, y);
        Vector3 direction = point - _spawnCenter.position;

        point = Quaternion.Euler(0, 0, UnityEngine.Random.Range(0, 360)) * direction;

        GameObject monster = Instantiate(_spawnMonsters[UnityEngine.Random.Range(0, 3)], point, Quaternion.identity);

        monster.GetComponent<Monster>().Spawner = this;
        monster.GetComponent<Monster>().Target = _spawnCenter.gameObject;

        _currentEntitiesCount++;
    }

    private void SpawnPapers() 
    {
        System.Random random = new System.Random();

        //spawn papers on constant positions
        for (int i = 0; i < 4; i++)
        {
            Vector3 spawnPoint = _remainedSpawnPoints[0].transform.position;
            Instantiate(_papers[0], spawnPoint, Quaternion.identity, _papersHolder);
            _remainedSpawnPoints.RemoveAt(0);
        }


        int index = 0;
        //spawn on remained positions
        for (int i = 0; i < _countOfAdditionalPapers; i++)  
        {
            index = random.Next(0, _remainedSpawnPoints.Count-1);
            Vector3 spawnPoint = _remainedSpawnPoints[index].transform.position;
            Instantiate(_papers[0], spawnPoint, Quaternion.identity, _papersHolder);
            _remainedSpawnPoints.RemoveAt(index);
        }
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

    public void OnMonsterDied() 
    {
        _currentEntitiesCount--;
    }

}