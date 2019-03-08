using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour {
    [SerializeField]
    private List<GameStateScene> _scenePrefabs;
    
    private List<GameStateScene> _scenes = new List<GameStateScene>();
    
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
        TurnOffAllScenes();

        if (scene == null) 
        {
            Debug.LogError("Scene was not found: " + type);
            return;
        }

        scene.CustomStart(data);
        scene.gameObject.SetActive(true);
    }

    private void OnDestroy() 
    {
        GameStateController.Instance.OnLoadScenes -= OnLoadScenes;
        GameStateController.Instance.OnGameStateChange -= OnGameStateChange;
    }
}
