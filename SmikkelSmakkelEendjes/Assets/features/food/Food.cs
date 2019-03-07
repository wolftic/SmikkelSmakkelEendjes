using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food  :  MonoBehaviour
{
    public int Speed
    {
        get;
        private set;
    }

    public int Size
    {
        get;
        private set;
    }

    public int ScoreAmount
    {
        get;
        private set;
    }

    public void Init(int speed, int size, int scoreAmount)
    {
        Reset();
        Speed = speed;
        Size = size;
        ScoreAmount = scoreAmount;
    }

    private void Reset()
    {
        Speed = 0;
        Size = 0;
        ScoreAmount = 0;
    }
}
