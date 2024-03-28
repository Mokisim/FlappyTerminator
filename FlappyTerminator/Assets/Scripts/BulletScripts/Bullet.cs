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
        if (collision.TryGetComponent<Player>(out Player player) == true && _bullet.TryGetComponent<PlayerBullet>(out PlayerBullet playerBullet) == false)
        {
            gameObject.SetActive(false);
        }
        else if (collision.TryGetComponent<Enemy>(out Enemy enemy) == true && _bullet.TryGetComponent<EnemyBullet>(out EnemyBullet enemyBullet) == false)
        {
            gameObject.SetActive(false);
            enemy.Die();
        }
        else if (collision.TryGetComponent<ObjectRemover>(out ObjectRemover objectRemover) == true)
        {
           gameObject.SetActive(false);
        }
        else if (collision.TryGetComponent<Ground>(out Ground ground) == true)
        {
            gameObject.SetActive(false);
        }
    }
}
