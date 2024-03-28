using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnRate;
    [SerializeField] private ObjectPool _pool;
    [SerializeField] private int _maxObjectCount;
    [SerializeField]private List<Transform> _points;
    
    private int _minObjectCount = 1;
    
    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        var wait = new WaitForSeconds(_spawnRate);

        while (enabled)
        {
            Spawn(GenerateRandomSpawnPoints());
            yield return wait;
        }
    }

    private void Spawn(List<Transform> randomPoints)
    {
        for (int i = 0; i < randomPoints.Count; i++)
        {
            Vector3 spawnPoint = new Vector3(transform.position.x, randomPoints[i].position.y, transform.position.z);

            var enemy = _pool.GetObject();

            enemy.gameObject.SetActive(true);
            enemy.transform.position = spawnPoint;
        }

        Vector3 scoreZoneSpawnPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        var scoreZone = _pool.GetZoneObject();

        scoreZone.gameObject.SetActive(true);
        scoreZone.transform.position = scoreZoneSpawnPoint;
    }

    private List<Transform> GenerateRandomSpawnPoints()
    {
        int randomObjectCount = Random.Range(_minObjectCount, _maxObjectCount);
        List<Transform> randomIndices = new List<Transform>(_points);
        List<Transform> randomPoints = new List<Transform>(randomObjectCount);
        int minRandomNumber = 0;

        while (randomPoints.Count < randomObjectCount)
        {
            int randomIndex = Random.Range(minRandomNumber, randomIndices.Count);

            randomPoints.Add(randomIndices[randomIndex]);
            randomIndices.RemoveAt(randomIndex);
        }

        return randomPoints;
    }
}
