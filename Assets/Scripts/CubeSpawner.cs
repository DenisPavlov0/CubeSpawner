using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private float _occurrenceInterval;
    [SerializeField] private float _distanceBetween;


    private readonly int _cubeAmount = 400;
    private int _counter;
    private Vector2 _position;
    public List<GameObject> _cube;
    private void Awake()
    {
        _position = new Vector2(-4, 4);
        StartCoroutine(SpawnCube());
    }

    private IEnumerator SpawnCube()
    {
        for (int i = 0; i < _cubeAmount; i++)
        {
            var cube = Instantiate(_cubePrefab, _position, Quaternion.identity);
            _cube.Add(cube);
            yield return new WaitForSeconds(_occurrenceInterval);
            _position.x += _distanceBetween;
            _counter++;
            if (_counter == 20)
            { 
                _counter = 0;
                _position.y -= 0.4f;
                _position.x = -4;
            }
        }
        
    }
}
