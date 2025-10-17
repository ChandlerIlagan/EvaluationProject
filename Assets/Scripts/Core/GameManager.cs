using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Action<int> OnScoreChange;
    public Action<int> OnTimeChange;
    public Action<GameState> OnGameStateChange;

    public static GameManager Instance;

    public GameState CurrentGameState
    {
        get => _currentGameState;
        set
        {
            _currentGameState = value;
            OnGameStateChange?.Invoke(value);
        }
    }  
    
    public int Score
    {
        get => _score;
        set
        {
            _score = value;
            OnScoreChange?.Invoke(value);
        }
    }  
    
    public int Timer
    {
        get => _timer;
        set
        {
            _timer = value;
            OnTimeChange?.Invoke(value);
        }
    }

    private GameState _currentGameState;
    private int _score = 0;
    private int _timer = 0;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Score = 0;

        CurrentGameState = GameState.Start;
    }

    private void OnDisable()
    {
        OnScoreChange = null;
    }
    
    public enum GameState
    {
        PreGame,
        Start,
        GameOver
    }
}
