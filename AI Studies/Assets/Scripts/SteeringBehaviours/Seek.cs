using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : SteeringBehaviour
{
    [SerializeField] Transform _target;

    public override Vector2 Calculate(MovingEntity entity)
    {
        Vector2 desiredVelocity = (_target.position - entity.transform.position).normalized * entity.maxSpeed;
        return desiredVelocity - entity.velocity;
    }

    public override void DrawGizmos()
    {
        if(!_target)
        {
            return;
        }

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_target.position, 0.5f);
    }
}
