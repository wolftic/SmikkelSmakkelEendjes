using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainStateScene : GameStateScene {
    public void PlayGame()
    {
        // start game
        GameStateController.Instance.SetState(GameStateType.IN_GAME);
    }

    public void OpenSettings()
    {
        // open settings menu
    }

    public void OpenCredits()
    {
        // open credits menu?
    }

    public void CloseGame() 
    {
        // show popup?
        // close game.

        Application.Quit();
    }
}
