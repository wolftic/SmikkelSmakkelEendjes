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
    
    [Header("Loading screen")]
    [SerializeField]
    private Text _loadingText;
    [SerializeField]
    private Image _progressBar;
    [SerializeField]
    private Canvas _loadingCanvas;

    [Header("Popups")]
    [SerializeField]
    private Canvas _popupCanvas;
    [SerializeField]
    private List<PopupBase> _popupsToSpawn;

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
        Reset();
        LoadGameStateController();
    }

    private void FinishLoadingSequence() 
    {
        PopupBase popup;
        for (int i = 0; i < _popupsToSpawn.Count; i++)
        {
            popup = Instantiate(_popupsToSpawn[i]).GetComponent<PopupBase>();
            popup.transform.SetParent(_popupCanvas.transform);
            popup.gameObject.SetActive(true);
            popup.transform.localPosition = Vector3.zero;
        }
        
        Debug.Log("Finished loading");
        _loadingCanvas.gameObject.SetActive(false);
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
        _loadingCanvas.gameObject.SetActive(true);
    }
}
