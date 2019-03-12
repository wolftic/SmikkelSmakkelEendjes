using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : Singleton<FoodController> {

    public Action<int> OnDestroyed;
    public Action<int> OnSpawned;
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
    public void SaveFood(Food[] food)
    {
        Foods = food;
        if (OnFoodSaved != null) OnFoodSaved();
    }
    public void MoveBackFood(Food food)
    {
        food.Position = new Vector3(Screen.width, food.Position.y);
    }
    public void MoveFood(Food food)
    {
        food.Position += new Vector3(-food.Speed, 0);
    }
}