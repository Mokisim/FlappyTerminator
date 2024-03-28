using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _attackSpeed;
    
    private float _nextAttackTime;
    private WaitForSeconds _wait;
    private InputReader _inputReader;
    private float _destroyDelay = 2f;

    private void Start()
    {
        _inputReader = GetComponent<InputReader>();
        _wait = new WaitForSeconds(_attackSpeed);
    }

    private void Update()
    {
        if (_inputReader.GetShootInput() == true && Time.time >= _nextAttackTime)
        {
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        _nextAttackTime = Time.time + _attackSpeed;
        Bullet bullet = Instantiate(_bulletPrefab, _attackPoint.position, _attackPoint.rotation);

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
