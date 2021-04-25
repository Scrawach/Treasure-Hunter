using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToCamera : MonoBehaviour
{
    private Transform _camera;
    
    private void Awake()
    {
        _camera = Camera.main.transform;
    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(_camera.transform.position);
    }
}
