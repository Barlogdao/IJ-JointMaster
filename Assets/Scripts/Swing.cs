using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    [SerializeField] private Transform _crossbar;

    [SerializeField] private float _maxAngle;
    [SerializeField] private float _speed;

    private bool _isSwinging = false;
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _isSwinging = !_isSwinging;
        }

        Rotate();
    }

    private void Rotate()
    {
        float angle;

        if (_isSwinging)
        {
             angle = _maxAngle * Mathf.Sin(Time.time * _speed);
        }
        else
        {
            angle = 0;
        }

        _crossbar.localRotation = Quaternion.Euler(angle, 0, 0);
    }
}
