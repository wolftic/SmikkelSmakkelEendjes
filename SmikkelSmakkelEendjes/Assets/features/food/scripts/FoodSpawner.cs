using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : Singleton<FoodSpawner> {

    private const int FOOD_AMOUNT = 4;
    private const int CHANCE_THRESHOLD = 20; //Percent chance of special food
    private const float FOOD_SPEED = 0.1f;
    private const int SPAWN_RATE = 1;

    private GameObject foodObject;

    public Action<Food[]> OnFoodCreated;    

    public void Init(GameObject foodObj)
    {
        GameObject[] _foods = new GameObject[FOOD_AMOUNT];
        Food[] _foodParameters = new Food[FOOD_AMOUNT];
        for (int i = 0; i < FOOD_AMOUNT; i++)
        {
            GameObject obj = Instantiate(foodObj, new Vector3(0, i), Quaternion.identity);
            Food tempFood = (Food)obj.AddComponent(typeof(Food));
            tempFood.Init(i, FOOD_SPEED, 1);
            _foodParameters[i] = tempFood;
            _foods[i] = obj;
        }
        FoodController.Instance.SaveFood(_foods, _foodParameters);
    }
}