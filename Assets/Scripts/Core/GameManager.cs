using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Action<int> OnScoreChange;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Score = 0;
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

    private int _score = 0;

    private void OnDisable()
    {
        OnScoreChange = null;
    }
}
