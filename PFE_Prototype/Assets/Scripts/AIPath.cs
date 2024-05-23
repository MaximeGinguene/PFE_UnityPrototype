using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AIPath : MonoBehaviour
{
    [SerializeField] private bool _pingPong = false; // if false close the path by connecting last --> first

    private List<Transform> _knots = new List<Transform>();

    private int targetIndex = 0;
    private bool inverseDirection = false;

    private void OnDrawGizmos()
    {
        if (_knots.Count < 1) return;

        for (int i = 0; i < _knots.Count - 1; i++)
        {
            Gizmos.DrawLine(_knots[i].position, _knots[i + 1].position);
        }

        if (!_pingPong) Gizmos.DrawLine(_knots[_knots.Count - 1].position, _knots[0].position);
    }

    private void Awake()
    {
        ComputePath();
    }

    private void ComputePath()
    {
        _knots.Clear();

        var children = transform.GetComponentsInChildren<AIKnot>();
        foreach (var child in children)
        {
            _knots.Add(child.transform);
        }
    }

    public Transform GetClosest(Vector3 position)
    {
        Transform closest = _knots[0];
        foreach (var knot in _knots)
        {
            if((knot.position - position).magnitude <= (closest.position - position).magnitude) closest = knot;
        }

        targetIndex = _knots.IndexOf(closest);
        return closest;
    }
    
    public Transform GetTarget()
    {
        return _knots[targetIndex];
    }

    public Transform NextTarget()
    {
        targetIndex += inverseDirection ? -1 : 1;
        if (targetIndex >= _knots.Count)
        {
            if (_pingPong)
            {
                inverseDirection = !inverseDirection;
                targetIndex = _knots.Count - 2;
            }
            else targetIndex = 0;
        }

        if (targetIndex < 0)
        {
            if (_pingPong)
            {
                inverseDirection = !inverseDirection;
                targetIndex = 1;
            }
            else targetIndex = _knots.Count - 1;
        }
        return _knots[targetIndex];
    }
}
