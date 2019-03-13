using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {
    private int _playerID;
    private int _playerScore;

    [SerializeField]
    private Text _scoreText;

    public void Init(int id)
    {
        _playerID = id;

        PlayerController.Instance.OnScoreRecieved += OnScoreRecieved;
        
        UpdateText();
    }

    private void OnScoreRecieved(int id, int score)
    {
        if (_playerID != id) return;

        _playerScore += score;

        UpdateText();
    }

    private void UpdateText() 
    {
        _scoreText.text = _playerScore.ToString();
    }

    /// <summary>
    /// Gets triggered by Unity UI Button
    /// </summary>
    public void Bite() 
    {
        PlayerController.Instance.RequestBite(_playerID);
    }

    private void OnDestroy()
    {
        if (PlayerController.HasInstance())
        {
            PlayerController.Instance.OnScoreRecieved -= OnScoreRecieved;
        }
    }
}
