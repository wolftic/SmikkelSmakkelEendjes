using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : Singleton<FoodSpawner> {

    private const int FOOD_AMOUNT = 10;
    private const int CHANCE_THRESHOLD = 20; //Percent chance of special food
    private const float MAX_FOOD_SPEED = 5f;
    private const float MIN_FOOD_SPEED = 1f;
    private const float MAX_ROTATION_SPEED = 0;
    private const float MIN_ROTATION_SPEED = -0;
    private const int SPAWN_RATE = 1;
    private string[] _foodNames = new string[]{"erwt1", "erwt2", "erwt3"};

    public Action<Food[]> OnFoodCreated;    

    public void Init(GameObject foodObj)
    {
        Food[] _foods = new Food[FOOD_AMOUNT];
        for (int i = 0; i < FOOD_AMOUNT; i++)
        {
            GameObject obj = Instantiate(foodObj, Vector3.zero, Quaternion.identity);
            Food tempFood = (Food)obj.AddComponent(typeof(Food));

            tempFood.Init(i, RandomSpeed(), RandomRotation(), 1, _foodNames[RandomSpriteIndex()]);
            
            _foods[i] = tempFood;
        }
        FoodController.Instance.SaveFood(_foods);
    }
    public void MoveBackFood(int id)
    {
        FoodController.Instance.InitFood(id, RandomSpeed(), RandomRotation(), 1, _foodNames[RandomSpriteIndex()]);
        FoodController.Instance.MoveBackFood(id);
    }
    public float RandomSpeed()
    {
        float randomSpeed = UnityEngine.Random.Range(MIN_FOOD_SPEED, MAX_FOOD_SPEED);
        return randomSpeed;
    }
    public float RandomRotation()
    {
        float randomSpeed = UnityEngine.Random.Range(MIN_ROTATION_SPEED, MAX_ROTATION_SPEED);
        return randomSpeed;
    }
    public int RandomSpriteIndex()
    {
        int randomSpriteIndex = UnityEngine.Random.Range(0, _foodNames.Length);
        return randomSpriteIndex;
    }
}