using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameStateScene : GameStateScene {
    private bool _playerVsBot = true;
    
    public void JoinPlayer()
    {
        _playerVsBot = false;
    }

    public void StartMatch()
    {
        PlayerController.Instance.AddPlayers(_playerVsBot ? 1 : 2);
    }

    public override void Open()
    {
        StartMatch();
    }
}
