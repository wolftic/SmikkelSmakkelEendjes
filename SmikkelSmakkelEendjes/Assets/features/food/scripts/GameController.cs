using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    [SerializeField]
    private Vector3[] _spawnPositions;

	void Start () {
		
	}
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            FoodSpawner.Instance.Init(_spawnPositions);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }
    }
}
