using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Enemy _prefab;
    [SerializeField] private ScoreZone _scoreZone;
    
    private Queue<Enemy> _pool;
    private Queue<ScoreZone> _scoreZonePool;
    
    public IEnumerable<Enemy> PooledObjects => _pool;
    public IEnumerable<ScoreZone> PooledScoreZones => _scoreZonePool;
    
    private void Awake()
    {
        _pool = new Queue<Enemy>();
        _scoreZonePool = new Queue<ScoreZone>();
    }

    public Enemy GetObject()
    {
        if( _pool.Count == 0 )
        {
            var enemy = Instantiate(_prefab);
            enemy.transform.parent = _container;

            return enemy;
        }

        return _pool.Dequeue();
    }

    public ScoreZone GetZoneObject()
    {
        if (_scoreZonePool.Count == 0)
        {
            var scoreZone = Instantiate(_scoreZone);
            scoreZone.transform.parent = _container;

            return scoreZone;
        }

        return _scoreZonePool.Dequeue();
    }

    public void PutObject(Enemy enemy)
    {
        _pool.Enqueue(enemy);
        enemy.gameObject.SetActive(false);
    }

    public void PutObject(ScoreZone scoreZone)
    {
        _scoreZonePool.Enqueue(scoreZone);
        scoreZone.gameObject.SetActive(false);
    }

    public void Reset()
    {
        _pool.Clear();
        _scoreZonePool.Clear();
    }
}
