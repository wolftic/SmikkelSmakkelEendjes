using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameStateScene : GameStateScene {
    [SerializeField]
    private GameObject _foodPrefab;
    [SerializeField]
    private List<GameObject> _spawnPositions = new List<GameObject>();
    [SerializeField]
    private GameObject _splashAnimation;
    
    private bool _playerVsBot = true;
    
    public void JoinPlayer()
    {
        _playerVsBot = false;
    }

    public void StartMatch()
    {
        PlayerController.Instance.AddPlayers(_playerVsBot ? 1 : 2);
        FoodController.Instance.Init(_spawnPositions, _splashAnimation);
        FoodSpawner.Instance.Init(_foodPrefab);
    }

    public override void Open()
    {
        StartMatch();
    }
}
