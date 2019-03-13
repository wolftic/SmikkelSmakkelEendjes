using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour {
    [SerializeField]
    private List<GameStateScene> _scenePrefabs;
    [SerializeField]
    private Image _transitionImage;
    
    private List<GameStateScene> _scenes = new List<GameStateScene>();
    private GameStateScene _currentScene;

    private void Awake() 
    {
        GameStateController.Instance.OnLoadScenes += OnLoadScenes;
        GameStateController.Instance.OnGameStateChange += OnGameStateChange;
    }

    private void OnLoadScenes() 
    {
        Debug.Log("Load scenes");
        GameStateScene scene;

        for (int i = 0; i < _scenePrefabs.Count; i++)
        {
            scene = Instantiate(_scenePrefabs[i].gameObject).GetComponent<GameStateScene>();
            scene.transform.SetParent(transform);
            _scenes.Add(scene);
        }

        TurnOffAllScenes();
        
        GameStateController.Instance.FinishLoadingScenes();
    }

    private void TurnOffAllScenes() 
    {
        for (int i = 0; i < _scenes.Count; i++)
        {
            _scenes[i].gameObject.SetActive(false);
        }
    }

    private GameStateScene GetScene(GameStateType type)
    {
        for (int i = 0; i < _scenes.Count; i++)
        {
            if (_scenes[i].Type == type) 
            {
                return _scenes[i];
            }
        }

        return null;
    }

    private void OnGameStateChange(GameStateType type, object data) 
    {
        GameStateScene scene = GetScene(type);

        if (scene == null) 
        {
            Debug.LogError("Scene was not found: " + type);
            return;
        }

        if (_currentScene != null) _currentScene.Close();

        _transitionImage.DOFade(1f, .33f).OnComplete(StartTransition);
        scene.CustomStart(data);

        _currentScene = scene;
    }

    private void StartTransition()
    {
        TurnOffAllScenes();
        _currentScene.gameObject.SetActive(true);
        _transitionImage.DOFade(0f, .33f).OnComplete(_currentScene.Open);
    }

    private void OnDestroy() 
    {
        if (GameStateController.HasInstance()) 
        {
            GameStateController.Instance.OnLoadScenes -= OnLoadScenes;
            GameStateController.Instance.OnGameStateChange -= OnGameStateChange;
        }
    }
}
