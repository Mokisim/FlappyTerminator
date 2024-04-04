using UnityEngine;

[RequireComponent(typeof(InputReader))]
public class PlayerAttacker : Attacker
{
    private InputReader _inputReader;
    
    private void Start()
    {
        _inputReader = GetComponent<InputReader>();
    }

    private void Update()
    {
        if (_inputReader.GetShootInput() == true && Time.time >= NextAttackTime)
        {
            StartCoroutine(Attack());
        }
    }

    private void OnDisable()
    {
        StopCoroutine(Attack());
    }
}
