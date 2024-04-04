using System;
using System.Collections;
using UnityEngine;

public abstract class Attacker : MonoBehaviour
{
    public event Action ObjectShooted;

    [SerializeField] protected Transform AttackPoint;
    [SerializeField] protected Bullet BulletPrefab;
    [SerializeField] protected float AttackSpeed;

    protected float NextAttackTime;
    protected WaitForSeconds Wait;

    private void Start()
    {
        Wait = new WaitForSeconds(AttackSpeed);
    }

    protected virtual IEnumerator Attack()
    {
        NextAttackTime = Time.time + AttackSpeed;

        ObjectShooted?.Invoke();

        yield return Wait;
    }
}
