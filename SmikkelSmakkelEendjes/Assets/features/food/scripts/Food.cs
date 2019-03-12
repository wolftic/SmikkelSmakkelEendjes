using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food  :  MonoBehaviour
{
    public Vector3 Position
    {
        get { return this.gameObject.transform.position; }
        set { this.gameObject.transform.position = value; }
    }

    public int Speed
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

    public void Init(int id, int speed, int scoreAmount)
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