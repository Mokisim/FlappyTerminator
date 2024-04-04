using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;

    private void OnEnable()
    {
        _spawner.EnemySpawned += ResetPosition;
    }

    private void OnDisable()
    {
        _spawner.EnemySpawned -= ResetPosition;
    }

    public void ResetPosition(Transform position)
    {
        transform.position = position.position;
    }
}
