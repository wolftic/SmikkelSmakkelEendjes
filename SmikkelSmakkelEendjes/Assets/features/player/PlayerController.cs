using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    public Action<int> OnPlayerBite;
    public Action<int, int> OnScoreRecieved;

    public Action<int> OnPlayerCreate;
    public Action OnResetAllPlayers;

    private List<int> _players = new List<int>();

    /// <summary>
    /// Initialize Player controller
    /// </summary>
    public void Init()
    {
        ResetAllPlayers();
    }

    /// <summary>
    /// Call bite and check for points
    /// </summary>
    /// <param name="playerId"></param>
    /// <param name="position"></param>
    public void Bite(int playerId, Vector3 position)
    {
        //can player bite? (powerup effects check)

        if (OnPlayerBite != null) OnPlayerBite(playerId);

        Collider2D[] colliders;

        // check if we hit food and also receive all colliders
        bool hit = HitCheckController.Instance.CheckHit(playerId, position, out colliders);

        //check if we hit some food
        if (hit)
        {
            Food food;
            int score = 0;

            // loop through all colliders
            for (int i = 0; i < colliders.Length; i++)
            {
                food = colliders[i].GetComponent<Food>();

                // check if the collider we've touched is actually food
                if (food == null) continue;

                // add score based on foods score amount
                score += food.ScoreAmount;
            }

            // give the score to the player with that id
            AddScore(score, playerId);
        }
    }

    /// <summary>
    /// Adds score to a player with 'id'
    /// </summary>
    /// <param name="score"></param>
    /// <param name="playerId"></param>
    public void AddScore(int score, int playerId)
    {
        if (OnScoreRecieved != null) OnScoreRecieved(playerId, score);
    }

    /// <summary>
    /// Create players
    /// </summary>
    /// <param name="playerAmount"></param>
    public void AddPlayers(int playerAmount)
    {
        ResetAllPlayers();

        for (int i = 0; i < playerAmount; i++)
        {
            AddPlayer(i);
        }
    }

    /// <summary>
    /// Create single player
    /// </summary>
    /// <param name="id"></param>
    private void AddPlayer(int id)
    {
        _players.Add(id);
        if (OnPlayerCreate != null) OnPlayerCreate(id);
    }

    /// <summary>
    /// Remove all players
    /// </summary>
    public void ResetAllPlayers()
    {
        _players.Clear();
        if (OnResetAllPlayers != null) OnResetAllPlayers();
    }
}