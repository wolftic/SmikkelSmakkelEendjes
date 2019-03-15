using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodChecker : MonoBehaviour {
    private const float SCREEN_WIDTH = 3f;
    [SerializeField]
    private GameObject _splashAnimation;
    void Update()
    {
        if (FoodController.Instance.Foods.Length <= 0) return;
        for (int i = 0; i < FoodController.Instance.Foods.Length; i++)
        {
            FoodController.Instance.MoveFood(i);
            FoodController.Instance.RotateFood(i);
            if(FoodController.Instance.Foods[i].transform.position.x <= -SCREEN_WIDTH)
            {
                FoodSpawner.Instance.MoveBackFood(i);
            }
        }
    }
}