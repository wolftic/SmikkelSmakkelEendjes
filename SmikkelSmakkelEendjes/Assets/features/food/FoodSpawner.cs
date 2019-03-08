using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : Singleton<FoodSpawner> {

    private const int FOOD_AMOUNT = 20;
    private const int CHANCE_THRESHOLD = 20; //Percent chance of special food
    private const int FOOD_SPEED = 1;

    public Action<Food[]> OnFoodCreated;

    private List<Food> _foods = new List<Food>();

	void Init ()
    {
        
	}
	
	void Update ()
    {
		
	}

    public void AddFood()
    {
        Food[] Foods = new Food[FOOD_AMOUNT];
        for (int i = 0; i < FOOD_AMOUNT; i++)
        {
            Foods[i] = new Food();
            Foods[i].Init(i, FOOD_SPEED, 1);
        }
        if (OnFoodCreated != null) OnFoodCreated(Foods);
    }
}