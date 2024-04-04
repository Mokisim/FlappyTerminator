using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D _bullet;

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
        if (collision.TryGetComponent<IDamageble>(out IDamageble creature) == true)
        {
            Destroy(gameObject);
            creature.TakeDamage();
        }
    }
}
