using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Gravity")]
    [SerializeField] private float _gravityAcceleration = -9.81f;
    [SerializeField] private float _maxVerticalVelocity = 20f;
    [SerializeField] private float _jumpHeight = 1f;

    [Header("Speed")] [SerializeField] private float _speed = 8f;

    private PlayerManager _playerManager;
    private CharacterController _characterController;
    
    private Vector3 _velocity = Vector3.zero;

    private bool _grounded;

    private void Start()
    {
        _playerManager = GetComponent<PlayerManager>();
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _grounded = _characterController.isGrounded;
        if (_grounded && _velocity.y < 0)
        {
            _velocity.y = 0f;
        }
        
        // Movement
        var input = _playerManager.FpvMoveAction.action.ReadValue<Vector2>();
        var movement = transform.forward * input.y;
        movement += transform.right * input.x;
        movement.Normalize();
        movement.y = 0;
        _characterController.Move((movement  * (_speed * Time.deltaTime)));
        
        // Changes the height position of the player..
        if (_playerManager.FpvJumpAction.action.IsPressed() && _grounded)
        {
            _velocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravityAcceleration);
        }
        _velocity.y += _gravityAcceleration * Time.deltaTime;
        
        // Cap y velocity
        _velocity.y = Mathf.Clamp(_velocity.y, -_maxVerticalVelocity, _maxVerticalVelocity);
        
        _characterController.Move(_velocity * Time.deltaTime);
    }
}