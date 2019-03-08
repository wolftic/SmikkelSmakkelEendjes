using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
                NOTE:
    IF YOU NEED TO LOAD SOMETHING
    INCREASE THE "AMOUNT OF LOADABLES"
    AND ADD A LOADING FUNCTION
    AND A LOADING DONE FUNCTION
    
    GOOD EXAMPLES ARE
    "LoadGameStateController()"
    AND "OnGameStateControllerLoaded()"
*/


public class Loader : MonoBehaviour {
    private const int AMOUNT_OF_LOADABLES = 2;
    
    [SerializeField]
    private Text _loadingText;
    [SerializeField]
    private Image _progressBar;

    private float _progress = 0f;
    private int _loaded = 0;

    private void Start() 
    {
        StartLoadingSequence();
    }

    private void AddProgress()
    {
        _loaded++;

        _progress = (float)_loaded / (float)AMOUNT_OF_LOADABLES;
        _progressBar.fillAmount = _progress;
        _loadingText.text = string.Concat((int)(_progress * 100f), "%");

        if (_loaded == AMOUNT_OF_LOADABLES) 
        {
            FinishLoadingSequence();
        }
    }

    private void StartLoadingSequence() 
    {
        LoadGameStateController();
    }

    private void FinishLoadingSequence() 
    {
        Debug.Log("Finished loading");
        GameStateController.Instance.SetState(GameStateType.MAIN_MENU);
    }

    private void LoadGameStateController() 
    {
        GameStateController.Instance.OnLoaded += OnGameStateControllerLoaded;
        GameStateController.Instance.Init();
    }

    private void OnGameStateControllerLoaded() 
    {
        GameStateController.Instance.OnLoaded -= OnGameStateControllerLoaded;
        AddProgress();
        LoadPlayerController();
    }

    private void LoadPlayerController() 
    {
        PlayerController.Instance.OnLoaded += OnPlayerControllerLoaded;
        PlayerController.Instance.Init();
    }

    private void OnPlayerControllerLoaded() 
    {
        PlayerController.Instance.OnLoaded -= OnPlayerControllerLoaded;
        AddProgress();
    }

    private void Reset() 
    {
        _progress = 0f;
        _loaded = 0;

        _loadingText.text = "";
        _progressBar.fillAmount = 0;
    }
}
