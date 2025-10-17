using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private void Start()
    {
        GameManager.Instance.OnScoreChange += UpdateScoreUI;
    }

    private void UpdateScoreUI(int value)
    {
        _scoreText.text = $"{value}";
    }
}
