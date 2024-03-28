using System;
using UnityEngine;


[RequireComponent(typeof(PlayerMovement), typeof(ScoreCounter), typeof(PlayerCollisionHandler))]
public class Player : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private PlayerCollisionHandler _playerCollisionHandler;
    private ScoreCounter _scoreCounter;

    public event Action GameOver;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _scoreCounter = GetComponent<ScoreCounter>();
        _playerCollisionHandler = GetComponent<PlayerCollisionHandler>();
    }

    private void OnEnable()
    {
        _playerCollisionHandler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _playerCollisionHandler.CollisionDetected -= ProcessCollision;
    }

    public void Reset()
    {
        _scoreCounter.Reset();
        _playerMovement.Reset();
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable.TryGetComponent(out Enemy enemy) == true)
        {
            GameOver?.Invoke();
        }
        else if (interactable.TryGetComponent(out ScoreZone scoreZone) == true)
        {
            _scoreCounter.Add();
        }
        else if(interactable.TryGetComponent(out Ground ground) == true)
        {
            GameOver?.Invoke();
        }
        else if(interactable.TryGetComponent(out EnemyBullet enemyBullet) == true)
        {
            GameOver?.Invoke();
        }
    }

}
