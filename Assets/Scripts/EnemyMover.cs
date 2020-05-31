using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _speed;

    private int _currentPoint = 0;


    private void Update()
    {
        Transform target = _points[_currentPoint];

        if (transform.position == target.position)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }

        transform.position =
            Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * _speed);
    }
}
