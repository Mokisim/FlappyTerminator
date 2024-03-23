using System.Collections;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private Transform _enemyAttackPoint;
    [SerializeField] private float _attackSpeed;
    [SerializeField] Rigidbody2D _bulletPrefab;

    private WaitForSeconds _wait;
    private float _nextAttackTime;

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
        Instantiate(_bulletPrefab, _enemyAttackPoint.position, Quaternion.identity);
        yield return _wait;
    }

    private void OnDisable()
    {
        StopCoroutine(Attack());
    }
}
