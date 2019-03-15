using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    protected int _playerID;
    [SerializeField]
    private int _playerScore;
    [SerializeField]
    private BoxCollider2D _biteField;
    [SerializeField]
    private Animator _animation;

    public void Init(int id)
    {
        _playerID = id;

        PlayerController.Instance.OnScoreRecieved += OnScoreRecieved;
        PlayerController.Instance.OnPlayerRequestBite += OnPlayerRequestBite;
        PlayerController.Instance.OnPlayerBite += OnBite;
    }
    
    private void Bite()
    {
        PlayerController.Instance.Bite(_playerID, _biteField.transform.position, _biteField.size);
    }

    private void OnPlayerRequestBite(int id)
    {
        if (_playerID != id) return;
        Bite();
    }

    private void OnBite(int id)
    {
        if (_playerID != id) return;

        //do animation
        _animation.SetTrigger("Eat");
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
        if (PlayerController.HasInstance())
        {
            PlayerController.Instance.OnScoreRecieved -= OnScoreRecieved;
            PlayerController.Instance.OnPlayerRequestBite -= OnPlayerRequestBite;
            PlayerController.Instance.OnPlayerBite -= OnBite;
        }
    }
}