using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    [Header("Gravity")]
    [SerializeField] private bool _hasGravity = true;
    [SerializeField] private float _gravityAcceleration = -9.81f;
    [SerializeField] private float _maxVerticalVelocity = 20f;
    [SerializeField] private float _jumpHeight = 1f;

    [Header("Speed")] [SerializeField] private float _speed = 8f;

    private CharacterController _characterController;
    
    private Vector3 _velocity = Vector3.zero;

    private bool _grounded;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    public void SimpleMove(Vector3 direction)
    {
        var grounded = _characterController.SimpleMove(direction);
        Debug.Log($"Character grounded: {grounded}");
    }
    
    void Move()
    {
        _grounded = _characterController.isGrounded;
        if (_grounded && _velocity.y < 0)
        {
            _velocity.y = 0f;
        }

        var move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _characterController.Move((move  * (_speed * Time.deltaTime)));

        // Reposition player forward transform
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && _grounded)
        {
            _velocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravityAcceleration);
        }
        _velocity.y += _gravityAcceleration * Time.deltaTime;
        
        // Cap velocity
        _velocity.y = Mathf.Clamp(_velocity.y, -_maxVerticalVelocity, _maxVerticalVelocity);
        
        _characterController.Move(_velocity * Time.deltaTime);
    }
}
