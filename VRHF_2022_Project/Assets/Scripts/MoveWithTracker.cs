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
        // target doesn't change over time, so only get it once
        _target ??= GetComponent<WaypointProgressTracker>().target;
        
        var pos = _transform.position;
        
        var heading = _target.position - pos;
        var distance = heading.magnitude;
        
        // prevent dividing by 0
        if (distance == 0) return;
        
        var direction = heading / distance;

        pos += direction * (velocity * Time.deltaTime);
        _transform.position = pos;
        
        // turn accordingly
        _transform.LookAt(_target);
    }
}
