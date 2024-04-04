using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private ObjectPool _pool;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private Attacker _attacker;

    private void OnEnable()
    {
        _attacker.ObjectShooted += Spawn;
    }

    private void OnDisable()
    {
        _attacker.ObjectShooted -= Spawn;
    }

    private void Spawn()
    {
        Vector3 spawnPoint = new Vector3(transform.position.x, _attackPoint.position.y, transform.position.z);

        var bullet = _pool.GetObject();

        bullet.gameObject.SetActive(true);
        bullet.transform.position = spawnPoint;
    }
}
