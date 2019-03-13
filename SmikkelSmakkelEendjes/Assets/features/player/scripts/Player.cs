using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private int _playerID;
    [SerializeField]
    private int _playerScore;
    [SerializeField]
    private BoxCollider2D _biteField;

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
        PlayerController.Instance.Bite(_playerID, _biteField.transform.position, _biteField.size);
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