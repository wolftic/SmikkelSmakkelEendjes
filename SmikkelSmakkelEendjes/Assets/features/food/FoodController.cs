using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : Singleton<FoodController> {

    public Action<int> OnDestroyed;
    public Action<int> OnSpawned;
    public Action OnFoodSaved;

    public Food[] Foods;
    public Food food;
    void Start()
    {
        FoodSpawner.Instance.OnFoodCreated += SaveFoodsToArray;
    }

    private void SaveFoodsToArray(Food[] foods)
    {
        Foods = foods;
        if (OnFoodSaved != null) OnFoodSaved();
    }

    public void OnDestroy(int id)
    {
        if (OnDestroyed != null) OnDestroyed(id);
    }
    
    void Update () {
		
	}
    private void MoveBackFood(Food food)
    {
        food.Position = new Vector3(Screen.width, food.Position.y);
    }
}
