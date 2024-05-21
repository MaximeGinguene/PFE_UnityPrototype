using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private bool _confineCursor = true;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _xRotationClamp;

    private PlayerManager _playerManager;
    
    private float _xRotation = 0f;
    
    private void Start()
    {
        _playerManager = GetComponent<PlayerManager>();
        
        if(_confineCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void Update()
    {
        // Input
        var viewInput = _playerManager.FpvViewAction.action.ReadValue<Vector2>();
        
        // Y Rotation
        transform.Rotate(Vector3.up * viewInput.x);
        
        // X Rotation
        _xRotation -= viewInput.y;
        _xRotation = Mathf.Clamp(_xRotation, -_xRotationClamp, _xRotationClamp);

        _cameraTransform.localRotation = Quaternion.Euler(Vector3.right * _xRotation);
    }
}
