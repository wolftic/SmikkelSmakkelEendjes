using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : Singleton<FoodController> {

    public Action<int> OnDestroyed;
    public Action<int> OnSpawned;
    public Action<int> OnScore;
    public Action<int> OnMovedBack;
    public Action OnFoodSaved;

    public Food[] Foods = new Food[] {};
    private List<GameObject> _spawnPoints = new List<GameObject>();
    private GameObject _splashAnimation;
    
    void Start()
    {

    }

    public void Destroy(int id)
    {
        if (OnDestroyed != null) OnDestroyed(id);

    }
    public void Init(List<GameObject> spawnPoints, GameObject splashAnim)
    {
        _splashAnimation = splashAnim;
        _spawnPoints = spawnPoints;
    }
    public void AddScore(int id)
    {
        if (OnScore != null) OnScore(Foods[id].ScoreAmount);
    }
    public void SaveFood(Food[] food)
    {
        Foods = food;

        for (int i = 0; i < food.Length; i++)
        {
            MoveBackFood(i);
        }
    }
    public void MoveBackFood(int id)
    {
        Foods[id].transform.position = GetRandomSpawnPoint();
    }
    public void MoveFood(int id)
    {
        Foods[id].transform.position += new Vector3(-Foods[id].Speed * Time.deltaTime, 0);
    }
    public void InitFood(int id, float speed, float rotationSpeed, int scoreAmount, string sprite)
    {
        Foods[id].Init(id, speed, rotationSpeed, scoreAmount, sprite);
    }
    public void RotateFood(int id)
    {
        Foods[id].transform.localEulerAngles += new Vector3(0, 0, Foods[id].RotationSpeed * Time.deltaTime);
    }
    
    public Vector3 GetRandomSpawnPoint()  
    {
        float res = UnityEngine.Random.Range(_spawnPoints[0].transform.position.y, _spawnPoints[_spawnPoints.Count - 1].transform.position.y);
        Vector3 result = new Vector3(_spawnPoints[0].transform.position.x, res);
        return result;
    }
    public void SpawnSplashAnimation(int id)
    {
        Destroy(Instantiate(_splashAnimation, FoodController.Instance.Foods[id].Position, Quaternion.identity), 0.75f);
    }
}