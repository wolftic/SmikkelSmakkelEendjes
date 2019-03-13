using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStateType {
    LOADING,
    MAIN_MENU,
    CHARACTER_SELECTION,
    IN_GAME,
    END_SCREEN
}

public class GameStateController : Singleton<GameStateController> {
    // loader stuff
    public Action OnLoaded;

    public GameStateType GameState 
    {
        private set;
        get;
    }
    
    public Action OnLoadScenes;
    public Action<GameStateType, object> OnGameStateChange;

    public void Init()
    {
        Reset();
        if (OnLoadScenes != null) OnLoadScenes();
    }

    #if UNITY_EDITOR
    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Alpha0)) {
            SetState(GameStateType.MAIN_MENU);   
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            SetState(GameStateType.IN_GAME);   
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            SetState(GameStateType.END_SCREEN);   
        }
    }
    #endif

    public void FinishLoadingScenes()
    {
        if (OnLoaded != null) OnLoaded();
    }

    public void SetState(GameStateType type, object customData = null) 
    {
        GameState = type;

        Debug.Log("Changing scene to: " + type);

        if (OnGameStateChange != null) OnGameStateChange(type, customData);
    }

    private void Reset() 
    {
        SetState(GameStateType.LOADING);
    }
}
