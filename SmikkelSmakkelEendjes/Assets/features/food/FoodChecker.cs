using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodChecker : MonoBehaviour {
    public Food[] Foods;

    private void Start()
    {
        
    }
    private IEnumerator CheckOutOfBounds()
    {
        for (int i = 0; i < Foods.Length; i++)
        {
            if (Foods[i].Position.x <= 0)
            {
                MoveBackFood(Foods[i]);
            }
        }
        yield return new WaitForSeconds()
        return null;
    }
}
