using System;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static EventHandler OnScoreTreshold;

    [SerializeField] private int _scoreToAdd = 10;
    private readonly int _scoreTreshold = 100;

    [SerializeField] private float _scoreTimerMax = 1f;
    private float _scoreTimer;

    private void Update()
    {
        if (!GameManager.Instance.IsGamePlaying() || GameManager.Instance.IsGamePaused())
        {
            return;
        }

        _scoreTimer += Time.deltaTime;

        if (_scoreTimer >= _scoreTimerMax)
        {
            _scoreTimer = 0;
            //DataManager.Instance.data.playerData.Score += _scoreToAdd;

            //if (DataManager.Instance.data.playerData.Score % _scoreTreshold == 0)
            //{
            //    OnScoreTreshold?.Invoke(this, EventArgs.Empty);
            //}
        }
    }
}