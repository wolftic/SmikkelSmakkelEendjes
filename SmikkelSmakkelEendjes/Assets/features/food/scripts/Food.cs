using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    public float Speed
    {
        get;
        private set;
    }

    public int ScoreAmount
    {
        get;
        private set;
    }

    public int ID
    {
        get;
        private set;
    }

    public Food(int id, float speed, int scoreAmount)
    {
        Speed = speed;
        ScoreAmount = scoreAmount;
        ID = id;
    }

    public void Init(int id, float speed, int scoreAmount)
    {
        Reset();
        Speed = speed;
        ScoreAmount = scoreAmount;
        ID = id;
    }

    private void Reset()
    {
        Speed = 0;
        ScoreAmount = 0;
    }
}