using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum AIStates
{
    Patrol,
    Pursuit
}

public class AIController : MonoBehaviour
{
    [SerializeField] private AIPath _path;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private float _pursuitDistance = 5f;

    private AIStates _aiState;

    private Transform _target;

    private PlayerManager _playerTarget;

    private void Start()
    {
        _aiState = AIStates.Patrol;
        _navMeshAgent.SetDestination(_path.GetTarget().position);
    }

    private void Update()
    {
        switch (_aiState)
        {
            case AIStates.Patrol:
                HandlePatrolState();
                break;
            case AIStates.Pursuit:
                HandlePursuitState();
                break;
        }
    }

    private void HandlePatrolState()
    {
        if ((transform.position - _navMeshAgent.destination).magnitude < 0.1f)
        {
            _navMeshAgent.SetDestination(_path.NextTarget().position);
        }
    }

    private void HandlePursuitState()
    {
        _navMeshAgent.SetDestination(_playerTarget.transform.position);
        if ((transform.position - _navMeshAgent.destination).magnitude > _pursuitDistance)
        {
            SetState(AIStates.Patrol);
            _navMeshAgent.SetDestination(_path.GetClosest(transform.position).position);
        }
    }

    public void SetTarget(Transform target)
    {
        _target = target;
        if (target.TryGetComponent<PlayerManager>(out _playerTarget))
        {
            SetState(AIStates.Pursuit);
        }
    }

    public void SetState(AIStates aiState)
    {
        _aiState = aiState;
    }
}
