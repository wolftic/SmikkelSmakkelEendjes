using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : Singleton<FoodSpawner> {

    private const int FOOD_AMOUNT = 4;
    private const int CHANCE_THRESHOLD = 20; //Percent chance of special food
    private const float MAX_FOOD_SPEED = 0.04f;
    private const float MIN_FOOD_SPEED = 0.01f;
    private const int SPAWN_RATE = 1;
    private string[] _foodNames = new string[]{"erwt1", "erwt2", "erwt3"};

    public Action<Food[]> OnFoodCreated;    

    public void Init(GameObject foodObj)
    {
        Food[] _foods = new Food[FOOD_AMOUNT];
        for (int i = 0; i < FOOD_AMOUNT; i++)
        {
            GameObject obj = Instantiate(foodObj, new Vector3(3, i), Quaternion.identity);
            Food tempFood = (Food)obj.AddComponent(typeof(Food));
            float randomSpeed = UnityEngine.Random.Range(MIN_FOOD_SPEED, MAX_FOOD_SPEED);
            int randomSpriteIndex = UnityEngine.Random.Range(0, _foodNames.Length);
            tempFood.Init(i, randomSpeed, randomSpeed * 500, 1, _foodNames[randomSpriteIndex]);
            _foods[i] = tempFood;
        }
        FoodController.Instance.SaveFood(_foods);
    }
    public void MoveBackFood(int id, float spawnPosX)
    {
        int randomSpriteIndex = UnityEngine.Random.Range(0, _foodNames.Length);
        float randomSpeed = UnityEngine.Random.Range(MIN_FOOD_SPEED, MAX_FOOD_SPEED);
        FoodController.Instance.InitFood(id, randomSpeed, randomSpeed * 500, 1, _foodNames[randomSpriteIndex]);
        FoodController.Instance.MoveBackFood(id, spawnPosX);
    }
}