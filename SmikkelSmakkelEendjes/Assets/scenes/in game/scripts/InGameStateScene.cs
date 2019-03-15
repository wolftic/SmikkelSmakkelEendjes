using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameStateScene : GameStateScene {
    [SerializeField]
    private GameObject _foodPrefab;
    [SerializeField]
    private List<GameObject> _spawnPositions = new List<GameObject>();
    
    private bool _playerVsBot = true;
    
    public void JoinPlayer()
    {
        _playerVsBot = false;
    }

    public void StartMatch()
    {
        PlayerController.Instance.AddPlayers(_playerVsBot ? 1 : 2);
        FoodController.Instance.Init(_spawnPositions);
        FoodSpawner.Instance.Init(_foodPrefab);
    }

    public override void Open()
    {
        StartMatch();
    }
}
