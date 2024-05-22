using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDetection : MonoBehaviour
{
    [SerializeField] private UnityEvent<Transform> _onPlayerEnter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerManager>(out var playerManager))
        {
            _onPlayerEnter.Invoke(other.transform);
        }
    }
}
