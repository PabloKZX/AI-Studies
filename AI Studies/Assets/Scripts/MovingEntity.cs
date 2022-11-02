using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEntity : MonoBehaviour
{
    public float mass;
    /// <summary>
    /// Maximum speed at which this entity may travel
    /// </summary>
    public float maxSpeed;
    /// <summary>
    /// Maximun force this entity can produce to power itself
    /// </summary>
    public float maxForce;
    /// <summary>
    /// Maximum rate (rad/seconds) at which this vehicle can rotate
    /// </summary>
    public float maxTurnRate;

    public SteeringBehaviour steeringBehaviour;

    [HideInInspector] public Vector2 velocity;
    [HideInInspector] public Vector2 heading;
    [HideInInspector] public Vector2 side;


    private void Update()
    {
        // Actual AI work
        if(steeringBehaviour == null)
        {
            Debug.LogError("Steering Behavour is null!");
            return;
        }
        Vector2 steeringForce = steeringBehaviour.Calculate(this);

        // F = ma -> a = F/m
        Vector2 acceleration = steeringForce / mass;

        velocity += acceleration * Time.deltaTime;
        velocity.x = Mathf.Min(velocity.x, maxSpeed);
        velocity.y = Mathf.Min(velocity.y, maxSpeed);

        transform.position += (Vector3)velocity * Time.deltaTime;

        if(velocity.magnitude < 0.0000001f)
        {
            return;
        }


        heading = velocity.normalized;
        side = heading.Perp();
        transform.right = heading;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, heading);
        Gizmos.DrawRay(transform.position, side);

        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, velocity);

        steeringBehaviour.DrawGizmos();
    }
}
