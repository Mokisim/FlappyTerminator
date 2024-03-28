using System.Collections;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private Transform _enemyAttackPoint;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private Bullet _bulletPrefab;

    private WaitForSeconds _wait;
    private float _nextAttackTime;
    private float _destroyDelay = 2f;

    private void Start()
    {
        _wait = new WaitForSeconds(_attackSpeed);
    }

    private void Update()
    {
        if (Time.time >= _nextAttackTime)
        {
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        _nextAttackTime = Time.time + _attackSpeed;
        Bullet bullet = Instantiate(_bulletPrefab, _enemyAttackPoint.position, _enemyAttackPoint.rotation);

        DestroyWithDelay(bullet);

        yield return _wait;
    }

    private void OnDisable()
    {
        StopCoroutine(Attack());
    }

    private void DestroyWithDelay(Bullet bullet)
    {
        Destroy(bullet.gameObject, _destroyDelay);
    }
}
