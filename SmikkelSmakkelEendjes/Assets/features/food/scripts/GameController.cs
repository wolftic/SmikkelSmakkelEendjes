using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    [SerializeField]
    private Vector3[] _spawnPositions;
    [SerializeField]
    private GameObject _foodObject;

	void Start () {
		
	}
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            FoodSpawner.Instance.Init(_foodObject);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }
    }
}
