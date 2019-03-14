using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreator : MonoBehaviour
{
    [SerializeField]
    private Player _playerPrefab, _botPrefab;
    [SerializeField]
    private PlayerUI _playerUIPrefab, _botUIPrefab;

    [SerializeField]
    private List<GameObject> _playerSpawnPoints, _playerUISpawnPoints;

    private List<Player> _players = new List<Player>();
    private List<PlayerUI> _playerUIs = new List<PlayerUI>();
       
    private void Awake()
    {
        PlayerController.Instance.OnPlayerCreate += OnPlayerCreate;
        PlayerController.Instance.OnResetAllPlayers += OnResetAllPlayers;
        PlayerController.Instance.OnPlayersCreated += OnPlayersCreated;
    }

    private void Start()
    {
        PlayerController.Instance.Init();
    }

    private void OnPlayerCreate(int id)
    {
        if (id >= _playerSpawnPoints.Count) return;

        Player player = CreatePlayer(id);

        PlayerUI playerUI = CreatePlayerUI(id);

        _players.Add(player);
        _playerUIs.Add(playerUI);
    }

    private void OnPlayersCreated() 
    {
        int botCount = _playerSpawnPoints.Count - PlayerController.Instance.PlayerCount;

        Debug.Log("botCount:"  + botCount);

        Bot bot;
        PlayerUI botUI;
        int id;
        
        for (int i = 0; i < botCount; i++)
        {
            id = PlayerController.Instance.PlayerCount + i;
            bot = CreateBot(id);
            botUI = CreateBotUI(id);

            _players.Add(bot);
            _playerUIs.Add(botUI);
        }
    }

    private Player CreatePlayer(int id) 
    {
        Player player = Instantiate(_playerPrefab.gameObject).GetComponent<Player>();
         
        player.transform.position = Vector3.zero;
        player.transform.SetParent(_playerSpawnPoints[id].transform, false);

        player.Init(id);
        return player;
    }

    private Bot CreateBot(int id)
    {
        Bot bot = Instantiate(_botPrefab.gameObject).GetComponent<Bot>();
         
        bot.transform.position = Vector3.zero;
        bot.transform.SetParent(_playerSpawnPoints[id].transform, false);

        bot.Init(id);
        return bot;
    }

    private PlayerUI CreatePlayerUI(int id) 
    {
        PlayerUI playerUI = Instantiate(_playerUIPrefab.gameObject).GetComponent<PlayerUI>();

        playerUI.transform.position = Vector3.zero;
        playerUI.transform.SetParent(_playerUISpawnPoints[id].transform, false);

        playerUI.Init(id);
        return playerUI;
    }

    private PlayerUI CreateBotUI(int id) 
    {
        PlayerUI botUI = Instantiate(_botUIPrefab.gameObject).GetComponent<PlayerUI>();

        botUI.transform.position = Vector3.zero;
        botUI.transform.SetParent(_playerUISpawnPoints[id].transform, false);

        botUI.Init(id);
        return botUI;
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
            PlayerController.Instance.OnPlayersCreated -= OnPlayersCreated;
        }
    }
}
