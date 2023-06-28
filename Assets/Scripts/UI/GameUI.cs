using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private TextMeshProUGUI _scoreText;

    private void Awake()
    {
        _pauseButton.onClick.AddListener(() =>
        {
            GameManager.Instance.TogglePauseGame();
        });
    }

    private void Start()
    {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
        GameManager.Instance.OnGamePaused += Instance_OnGamePaused;
        GameManager.Instance.OnGameUnpaused += Instance_OnGameUnpaused;

        //DataManager.Instance.data.playerData.OnScoreChanged += DataManager_OnScoreChanged;

        Hide();
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnStateChanged -= GameManager_OnStateChanged;
        GameManager.Instance.OnGamePaused -= Instance_OnGamePaused;
        GameManager.Instance.OnGameUnpaused -= Instance_OnGameUnpaused;

        //DataManager.Instance.data.playerData.OnScoreChanged -= DataManager_OnScoreChanged;
    }

    private void Instance_OnGamePaused(object sender, EventArgs e)
    {
        Hide();
    }

    private void Instance_OnGameUnpaused(object sender, EventArgs e)
    {
        Show();
    }

    private void GameManager_OnStateChanged(object sender, EventArgs e)
    {
        if (GameManager.Instance.IsGamePlaying())
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void DataManager_OnScoreChanged(int obj)
    {
        //_scoreText.text = DataManager.Instance.data.playerData.Score.ToString("000000");
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
