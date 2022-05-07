using System;
using UnityEngine;
using UnityStandardAssets.Utility;

public class MoveWithTracker : MonoBehaviour
{
    public float velocity = 10;

    private Transform _transform;
    private Transform _target;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        _target ??= GetComponent<WaypointProgressTracker>().target;
        
        var pos = _transform.position;
        
        var heading = _target.position - pos;
        var distance = heading.magnitude;
        
        if (distance == 0) return;
        
        var direction = heading / distance;

        pos += direction * (velocity * Time.deltaTime);
        _transform.position = pos;
    }
}
