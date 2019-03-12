using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : Singleton<FoodSpawner> {

    private const int FOOD_AMOUNT = 4;
    private const int CHANCE_THRESHOLD = 20; //Percent chance of special food
    private const int FOOD_SPEED = 1;
    private const int SPAWN_RATE = 1;


    public Action<Food[]> OnFoodCreated;    

    public void Init(Vector3[] spawnPoints)
    {
        Food[] _foods = new Food[FOOD_AMOUNT];
        for (int i = 0; i < FOOD_AMOUNT; i++)
        {
            GameObject tempObj = new GameObject();
            Food tempFood = (Food)tempObj.AddComponent(typeof(Food));
            int randomPosition = UnityEngine.Random.Range(0, spawnPoints.Length);
            tempFood.Init(i, FOOD_SPEED, 1);
            _foods[i] = tempFood;
            _foods[i].Position = spawnPoints[randomPosition];
        }
        FoodController.Instance.SaveFood(_foods);
        if (OnFoodCreated != null) OnFoodCreated(_foods);
    }
}