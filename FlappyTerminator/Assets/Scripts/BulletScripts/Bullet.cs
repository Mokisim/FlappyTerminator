using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D _bullet;

    public Action PlayerDamaged;
    public Action EnemyDamaged;

    private void Awake()
    {
        _bullet = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _bullet.velocity = transform.right * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_bullet.TryGetComponent<PlayerBullet>(out PlayerBullet playerBullet) == false)
        {
            Destroy(gameObject);
        }
        else if (collision.TryGetComponent<Enemy>(out Enemy enemy) == true)
        {
            Destroy(gameObject);
            enemy.Die();
        }
        else if (collision.TryGetComponent<ObjectRemover>(out ObjectRemover objectRemover) == true)
        {
            Destroy(gameObject);
        }
    }
}
