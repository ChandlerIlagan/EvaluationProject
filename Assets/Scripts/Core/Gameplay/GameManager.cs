using System;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            if (value == GameState.GameOver || value == GameState.Win)
                Time.timeScale = 0;
                
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

    [SerializeField] private int _score = 0;
    [SerializeField] private int _timer = 0;
    
    private GameState _currentGameState;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Score = 0;
        Invoke(nameof(StartGame), 0.5f);
    }

    private void StartGame()
    {
        CurrentGameState = GameState.Start;
        TickTimer();
    }

    private void TickTimer()
    {
        Timer--;
        
        if (Timer <= 0)
            CurrentGameState = GameState.Win;
        
        if (CurrentGameState == GameState.Start)
            Invoke(nameof(TickTimer), 1.0f);
    }

    public void PauseGame()
    {
        CurrentGameState = GameState.Pause;
        Time.timeScale = 0;
    }
    
    public void UnpauseGame()
    {
        CurrentGameState = GameState.Start;
        Time.timeScale = 1;
    }
    private void OnDisable()
    {
        OnScoreChange = null;
    }

    public void RestartScene()
    {
        UnpauseGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public enum GameState
    {
        PreGame,
        Start,
        Pause,
        GameOver,
        Win
    }
}
