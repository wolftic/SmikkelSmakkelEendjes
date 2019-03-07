using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreator : MonoBehaviour
{
    [SerializeField]
    private Player _playerPrefab;

    private List<Player> _players = new List<Player>();
       
    private void Awake()
    {
        PlayerController.Instance.OnPlayerCreate += OnPlayerCreate;
        PlayerController.Instance.OnResetAllPlayers += OnResetAllPlayers;
    }

    private void Start()
    {
        PlayerController.Instance.Init();
    }

    private void OnPlayerCreate(int id)
    {
        Player player = Instantiate(_playerPrefab);

        player.Init(id);

        _players.Add(player);
    }

    private void OnResetAllPlayers()
    {
        for (int i = 0; i < _players.Count; i++)
        {
            Destroy(_players[i].gameObject);
        }

        _players.Clear();
    }

    private void OnDestroy()
    {
        PlayerController.Instance.OnPlayerCreate -= OnPlayerCreate;
        PlayerController.Instance.OnResetAllPlayers -= OnResetAllPlayers;
    }
}
