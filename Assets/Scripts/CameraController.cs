using Cinemachine;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private List<CinemachineVirtualCamera> _cameras;

    private int _currentCameraIndex = 0;
    private int _maxPriority = 100;
    private int _minPriority = 1;

    private void Start()
    {
        _cameras[_currentCameraIndex].Priority = _maxPriority;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchCamera();
        }
    }

    private void SwitchCamera()
    {
        _currentCameraIndex = (_currentCameraIndex + 1) % _cameras.Count;

        for (int i = 0; i < _cameras.Count; i++)
        {
            if (i == _currentCameraIndex)
            {
                _cameras[i].Priority = _maxPriority;
            }
            else
            {
                _cameras[i].Priority = _minPriority;
            }
        }
    }
}
