using System;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float velocity = 10;
    public Transform[] targets;
    public float threshold = .05f;

    private Transform _transform;
    private int _id;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        var pos = _transform.position;
        
        var heading = targets[_id].position - pos;
        var distance = heading.magnitude;

        if (distance < threshold)
        {
            _id = ++_id % targets.Length;
            Debug.Log($"Current Target ID: {_id}");
            return;
        }
        
        var direction = heading / distance;

        pos += direction * (velocity * Time.deltaTime);
        _transform.position = pos;
    }
}
