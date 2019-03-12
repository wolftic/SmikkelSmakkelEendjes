using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodChecker : MonoBehaviour {

    private void Start()
    {
        FoodController.Instance.OnFoodSaved += StartChecking;
    }
    void Update()
    {
        if (FoodController.Instance.Foods.Length <= 0) return;
        for (int i = 0; i < FoodController.Instance.Foods.Length; i++)
        {
            FoodController.Instance.MoveFood(FoodController.Instance.Foods[i]);
        }
    }
    private void StartChecking()
    {
        StartCoroutine(CheckOutOfBounds());
    }
    private IEnumerator CheckOutOfBounds()
    {
        Food[] Foods = FoodController.Instance.Foods;
        for (int i = 0; i < Foods.Length; i++)
        {
            if (Foods[i].Position.x <= 0)
            {
                FoodController.Instance.MoveBackFood(Foods[i]);
            }
        }
        yield return new WaitForSeconds(0.1f);
    }
}