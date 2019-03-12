using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodChecker : MonoBehaviour {

    private void Start()
    {
        //FoodController.Instance.OnFoodSaved += StartChecking;
    }
    void Update()
    {
        if (FoodController.Instance.Foods.Length <= 0) return;
        for (int i = 0; i < FoodController.Instance.Foods.Length; i++)
        {
            FoodController.Instance.MoveFood(FoodController.Instance.FoodParameters[i].ID);
            if(FoodController.Instance.Foods[i].transform.position.x <= -5)
            {
                FoodController.Instance.MoveBackFood(i);
            }
        }
    }
}