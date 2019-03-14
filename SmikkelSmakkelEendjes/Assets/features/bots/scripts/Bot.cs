using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : Player {
    [SerializeField]
    private float _minBiteInterval = .5f;
    [SerializeField]
    private float _maxBiteInterval = 1f;

    private float _nextBiteTime;

    private void Update()
    {
        if (_nextBiteTime < Time.time) 
        {
            _nextBiteTime = Time.time + GetRandomInterval();
            RequestBite();
        }
    }

    private void RequestBite()
    {
        PlayerController.Instance.RequestBite(_playerID);
    }

    private float GetRandomInterval()
    {
        return Random.Range(_minBiteInterval, _maxBiteInterval);
    }
}
