using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : Singleton<FoodController> {

    public Action<int> OnDestroyed;
    public Action<int> OnSpawned;
    public Action OnFoodSaved;

    public GameObject[] Foods;
    public Food[] FoodParameters;
    void Start()
    {

    }

    public void Destroy(int id)
    {
        if (OnDestroyed != null) OnDestroyed(id);

    }
    
    void Update () {
		
	}
    public void SaveFood(GameObject[] foodObj, Food[] food)
    {
        Foods = foodObj;
        FoodParameters = food;
    }
    public void MoveBackFood(int id)
    {
        Foods[id].transform.position = new Vector3(6, id);
    }
    public void MoveFood(int id)
    {
        Foods[id].transform.position += new Vector3(-FoodParameters[id].Speed, 0);
        print(-FoodParameters[id].Speed);
    }
}