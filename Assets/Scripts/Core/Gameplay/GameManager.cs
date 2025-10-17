using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Action<int> OnScoreChange;
    public Action<int> OnTimeChange;
    public Action<int> OnLivesChange;
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
    
    public int Lives
    {
        get => _lives;
        set
        {
            _lives = value;
            OnLivesChange?.Invoke(value);
        }
    }

    public int Level => _level;

    [SerializeField] private int _level = 1;
    [SerializeField] private int _score = 0;
    [SerializeField] private int _timer = 0;
    [SerializeField] private int _lives = 0;
    
    [Header("Dependencies")]
    [SerializeField] private Slider _volumeSlider;
    
    private GameState _currentGameState;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Time.timeScale = 0;
        Score = 0;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        GetComponent<AudioSource>().Play();
        _volumeSlider.value = GetComponent<AudioSource>().volume;
        CurrentGameState = GameState.Start;
        TickTimer();
    }

    public void OnVolumeChange(float value)
    {
        GetComponent<AudioSource>().volume = value;
    }

    private void TickTimer()
    {
        Timer--;

        if (Timer <= 60)
            _level = 2;
        else if (Timer <= 30)
            _level = 3;
        else if (Timer <= 0)
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
        OnLivesChange = null;
        OnTimeChange = null;
        OnGameStateChange = null;
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
