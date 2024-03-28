using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    [SerializeField] private ObjectPool _pool;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            _pool.PutObject(enemy);
        }

        if(other.TryGetComponent(out ScoreZone zone))
        {
            _pool.PutObject(zone);
        }

        if(other.TryGetComponent(out Bullet bullet))
        {
            bullet.gameObject.SetActive(false);
        }
    }
}
