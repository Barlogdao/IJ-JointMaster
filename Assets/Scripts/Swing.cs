using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    [SerializeField] private Transform _crossbar;

    [SerializeField] private float _minAngle;
    [SerializeField] private float _maxAngle;
    [SerializeField] private float _speed;

    private bool _isSwinging;
    private float _targetAngle;

    private void Update()
    {
        
    }

    private void Rotate()
    {
        if (_isSwinging == false)
        {
            _targetAngle = 0;
        }
        else
        {
            
        }
    }
}
