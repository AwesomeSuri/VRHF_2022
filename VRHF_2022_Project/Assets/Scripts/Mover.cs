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
        // getting the transform via "transform" everytime is not efficient, better store the reference
        _transform = transform;
    }

    private void Update()
    {
        var pos = _transform.position;
        
        var heading = targets[_id].position - pos;
        var distance = heading.magnitude;

        // mathematically, this object will never reach the target using position interpolation
        // => use a distance threshold
        if (distance < threshold)
        {
            // increment target id and start from 0 when end is reached
            _id = ++_id % targets.Length;
            Debug.Log($"Current Target ID: {_id}");
            
            // abort function
            return;
        }
        
        // calculate direction after if clause to prevent division with 0
        var direction = heading / distance;

        // interpolate position
        pos += direction * (velocity * Time.deltaTime);
        _transform.position = pos;
    }
}
