using System;
using UnityEngine;

public class Game : MonoBehaviour
{
    public event Action GameOver;

    [SerializeField] private Player _player;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndGameScreen _endScreen;
    [SerializeField] private ObjectPool _objectPool;
    [SerializeField] private ObjectPool _playerBulletsPool;
    [SerializeField] private ObjectPool _enemyBulletsPool;
    [SerializeField] private Transform _container;
    [SerializeField] private ScoreZone _scoreZone;

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }
    
    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += OnPlayButtonClick;
        _endScreen.RestartButtonClicked += OnRestartButtonClick;
        _player.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClick;
        _endScreen.RestartButtonClicked -= OnRestartButtonClick;
        _player.GameOver -= OnGameOver;
    }

    private void OnGameOver()
    {
        GameOver?.Invoke();
        Time.timeScale = 0;
        _endScreen.Open();
        _scoreZone.transform.position = _container.transform.position;
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _player.Reset();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void OnRestartButtonClick()
    {
        _endScreen.Close();
        StartGame();
    }
}
