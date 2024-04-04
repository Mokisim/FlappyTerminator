using UnityEngine;

public class EnemyAttacker : Attacker
{
    private void Start()
    {
        Wait = new WaitForSeconds(AttackSpeed);
    }

    private void Update()
    {
        if (Time.time >= NextAttackTime)
        {
            StartCoroutine(Attack());
        }
    }

    private void OnDisable()
    {
        StopCoroutine(Attack());
    }
}
