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

    public Food[] Foods;
    void Start()
    {

    }

    public void Destroy(int id)
    {
        if (OnDestroyed != null) OnDestroyed(id);

    }
    
    void Update () {
	}
    public void AddScore(int id)
    {
        if (OnScore != null) OnScore(Foods[id].ScoreAmount);
    }
    public void SaveFood(Food[] food)
    {
        Foods = food;
    }
    public void MoveBackFood(int id, float moveAmount)
    {
        Foods[id].transform.position = new Vector3(moveAmount, id);
    }
    public void MoveFood(int id)
    {
        Foods[id].transform.position += new Vector3(-Foods[id].Speed, 0);
    }
    public void InitFood(int id, float speed, float rotationSpeed, int scoreAmount, string sprite)
    {
        Foods[id].Init(id, speed, rotationSpeed, scoreAmount, sprite);
    }
    public void RotateFood(int id)
    {
        Foods[id].transform.localEulerAngles += new Vector3(0, 0, Foods[id].RotationSpeed);
    }
}