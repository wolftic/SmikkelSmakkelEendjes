using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public Vector3 Position
    {
        get { return this.transform.position; }
        set { this.transform.position = value; }
    }
    public Vector3 Rotation
    {
        get { return this.transform.localEulerAngles; }
        set { this.transform.localEulerAngles = value; }
    }
    public Sprite Sprite
    {
        get { return this.GetComponent<SpriteRenderer>().sprite; }
        set { this.GetComponent<SpriteRenderer>().sprite = value; }
    }
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

    public float RotationSpeed
    {
        get;
        private set;
    }

    public void Init(int id, float speed, float rotationSpeed, int scoreAmount, string sprite)
    {
        Speed = speed;
        ScoreAmount = scoreAmount;
        ID = id;
        RotationSpeed = rotationSpeed;
        Sprite = Resources.Load<Sprite>(sprite);
    }
}