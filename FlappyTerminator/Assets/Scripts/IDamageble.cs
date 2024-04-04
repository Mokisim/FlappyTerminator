using UnityEngine;

public class IDamageble : MonoBehaviour
{
    public void TakeDamage()
    {
        if (gameObject.TryGetComponent<Enemy>(out Enemy enemy) == true)
        {
            gameObject.SetActive(false);
        }
    }
}
