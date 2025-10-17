using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _gameOverScoreText;
    [SerializeField] private TextMeshProUGUI _winScoreText;
    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _winPanel;
    private void Start()
    {
        GameManager.Instance.OnScoreChange += UpdateScoreUI;
        GameManager.Instance.OnTimeChange += UpdateTimeUI;
        GameManager.Instance.OnGameStateChange += OnGameStateChanged;
    }

    private void OnGameStateChanged(GameManager.GameState state)
    {
        switch (state)
        {
            case GameManager.GameState.GameOver:
                _gameOverPanel.SetActive(true);
                break;
            
            case GameManager.GameState.Win:
                _winPanel.SetActive(true);
                break;
            
            case GameManager.GameState.Pause:
                _pausePanel.SetActive(true);
                break;
        }
    }

    private void UpdateScoreUI(int value)
    {
        _scoreText.text = $"{value}";
    }
    
    private void UpdateTimeUI(int value)
    {
        _timeText.text = $"{value}";
    }
}
