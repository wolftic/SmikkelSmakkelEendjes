using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreator : MonoBehaviour
{
    [SerializeField]
    private Player _playerPrefab;
    [SerializeField]
    private PlayerUI _playerUIPrefab;

    [SerializeField]
    private List<GameObject> _playerSpawnPoints, _playerUISpawnPoints;

    private List<Player> _players = new List<Player>();
    private List<PlayerUI> _playerUIs = new List<PlayerUI>();
       
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
        if (id >= _playerSpawnPoints.Count) return;

        Player player = Instantiate(_playerPrefab.gameObject).GetComponent<Player>();
         
        player.transform.position = Vector3.zero;
        player.transform.SetParent(_playerSpawnPoints[id].transform, false);

        player.Init(id);

        PlayerUI playerUI = Instantiate(_playerUIPrefab.gameObject).GetComponent<PlayerUI>();

        playerUI.transform.position = Vector3.zero;
        playerUI.transform.SetParent(_playerUISpawnPoints[id].transform, false);

        playerUI.Init(id);

        _players.Add(player);
        _playerUIs.Add(playerUI);
    }

    private void OnResetAllPlayers()
    {
        for (int i = 0; i < _players.Count; i++)
        {
            Destroy(_players[i].gameObject);
        }

        for (int i = 0; i < _playerUIs.Count; i++)
        {
            Destroy(_playerUIs[i].gameObject);
        }

        _players.Clear();
        _playerUIs.Clear();
    }

    private void OnDestroy()
    {
        if (PlayerController.HasInstance())
        {
            PlayerController.Instance.OnPlayerCreate -= OnPlayerCreate;
            PlayerController.Instance.OnResetAllPlayers -= OnResetAllPlayers;
        }
    }
}
