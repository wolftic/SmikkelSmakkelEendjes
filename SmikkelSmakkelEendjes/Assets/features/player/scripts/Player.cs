using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _playerID;
    private int _playerScore;

    public void Init(int id)
    {
        _playerID = id;

        PlayerController.Instance.OnScoreRecieved += OnScoreRecieved;
        PlayerController.Instance.OnPlayerBite += OnBite;
    }

    /// <summary>
    /// Gets triggered by Unity UI Button
    /// </summary>
    public void Bite()
    {
        PlayerController.Instance.Bite(_playerID, transform.position);
    }

    private void OnBite(int id)
    {
        if (_playerID != id) return;

        //do animation
    }

    private void OnScoreRecieved(int id, int score)
    {
        if (_playerID != id) return;

        _playerScore += score;
    }

    /*public void Reset()
    {

    }*/

    private void OnDestroy()
    {
        PlayerController.Instance.OnScoreRecieved -= OnScoreRecieved;
        PlayerController.Instance.OnPlayerBite -= OnBite;
    }
}